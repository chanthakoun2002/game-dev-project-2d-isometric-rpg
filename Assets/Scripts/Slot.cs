using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private void Start() {
         
    }
    
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        if(transform.childCount <= 0){
            inventory.isFull[i] = false;
        }
    }
    public void DropItem(){
        foreach (Transform child in transform){
            child.GetComponent<Spawn>().spawnDroppedItem();
            inventory.isFull[i] = false;
            Destroy(child.gameObject);
            
        }
    }
}
