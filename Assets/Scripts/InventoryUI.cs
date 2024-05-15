// using UnityEngine;
// using UnityEngine.UI;

// public class InventoryUI : MonoBehaviour
// {
//     public Inventory playerInventory; // Reference to the player's inventory

//     public GameObject[] slots; // Array of UI slots representing inventory slots

//     void Update()
//     {
//         UpdateUI();
//     }

//     void UpdateUI()
//     {
//         // Iterate through each slot in the UI
//         for (int i = 0; i < slots.Length; i++)
//         {
//             // Check if there is a corresponding potion in the player's inventory
//             if (i < playerInventory.potions.Count)
//             {
//                 // If a potion exists in this slot, update the UI to display its information
//                 Potion potion = playerInventory.potions[i];
//                 Image icon = slots[i].GetComponent<Image>();
//                 Text nameText = slots[i].transform.Find("Name").GetComponent<Text>();
//                 Text descriptionText = slots[i].transform.Find("Description").GetComponent<Text>();

//                 icon.sprite = potion.artwork;
//                 nameText.text = potion.name;
//                 descriptionText.text = potion.description;
//             }
//             else
//             {
//                 // If no potion exists in this slot, clear the UI
//                 Image icon = slots[i].GetComponent<Image>();
//                 Text nameText = slots[i].transform.Find("Name").GetComponent<Text>();
//                 Text descriptionText = slots[i].transform.Find("Description").GetComponent<Text>();

//                 icon.sprite = null;
//                 nameText.text = "";
//                 descriptionText.text = "";
//             }
//         }
//     }
// }