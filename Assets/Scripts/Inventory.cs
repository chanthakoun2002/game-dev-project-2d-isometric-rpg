using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public void AddItem(GameObject itemPrefab)
    {
        // Loop through inventory slots to find an empty slot
        for (int i = 0; i < slots.Length; i++)
        {
            if (!isFull[i])
            {
                // Instantiate the item prefab in the empty slot
                Instantiate(itemPrefab, slots[i].transform, false);
                // Mark the slot as occupied
                isFull[i] = true;
                // Exit the loop since the item has been added
                break;
            }
        }
    }
    
}
