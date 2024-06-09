using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private bool isPickedUp= false; 
    void Start()
    {
        //inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        StartCoroutine(WaitForPlayer());
    }
    IEnumerator WaitForPlayer()
    {
        //wait until the player is found
        while (inventory == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                inventory = player.GetComponent<Inventory>();
            }
            yield return null; 
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !isPickedUp){
            isPickedUp = true; //this is to prevent re-triggering to prevent multiplication of items in iventory
            AddItemToIventory();
        }
    }
    void AddItemToIventory(){
        for(int i = 0; i < inventory.slots.Length; i++){
                if(inventory.isFull[i] == false){
                    
                    //item is added to inventory and check for if inventory is filled
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Debug.Log("Adding item to inventory slot: " + i);
                    Destroy(gameObject);
                    break;
                }
       } 
    }
}
