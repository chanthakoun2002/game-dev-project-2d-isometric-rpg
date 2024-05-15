using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private void Start() {
         inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void Update()
    {
        if(transform.childCount <= 0){
            inventory.isFull[i] = false;
        }
    }
    public void DropItem(){
        foreach (Transform child in transform){
            child.GetComponent<Spawn>().spawnDroppedItem();
            GameManager.Destroy(child.gameObject);
        }
    }
}
