using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public List<string> items;
}

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public bool[] isFull;
    public GameObject[] slots;
    private bool loaded = false;
    private List<string> inventoryItems = new List<string>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        isFull = new bool[slots.Length];
    }
    public void AddItem(GameObject itemPrefab)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!isFull[i])
            {
                GameObject newItem = Instantiate(itemPrefab, slots[i].transform);
                newItem.name = itemPrefab.name; 
                isFull[i] = true;
                break;
            }
        }
    }

    public void SaveInventory()
    {
        InventoryData data = new InventoryData();
        data.items = new List<string>();

        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
                GameObject item = slots[i].transform.GetChild(0).gameObject;
                string itemName = item.name.Replace("(Clone)", "").Trim();
                data.items.Add(itemName);
            }
        }

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PlayerData.InventoryKey, json);
        PlayerPrefs.Save();
        Debug.Log("Inventory saved: " + json);

    }

    public void LoadInventory()
    {   
        
        if (!loaded && PlayerPrefs.HasKey(PlayerData.InventoryKey)){
        if (PlayerPrefs.HasKey(PlayerData.InventoryKey))
        {
            string json = PlayerPrefs.GetString(PlayerData.InventoryKey);
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);

            for (int i = 0; i < data.items.Count; i++)
            {
                string itemName = data.items[i];
                GameObject itemPrefab = Resources.Load<GameObject>(itemName);
                if (itemPrefab != null)
                {
                    AddItem(itemPrefab);
                    
                }
                else
                {
                    Debug.LogError("Item prefab not found: " + itemName);
                }
            }
        }
        loaded = true;
        Debug.Log("Inventory loaded for scene: " + PlayerPrefs.GetString(PlayerData.InventoryKey));
        }
    }
    public void ClearInventory()//clear inventory when needed
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
                foreach (Transform child in slots[i].transform)
                {
                    Destroy(child.gameObject);
                }
                isFull[i] = false;
            }
        }
        PlayerPrefs.DeleteKey(PlayerData.InventoryKey);
    }
    //below methods are needed for saving and loading with json file related to the players inventory
    public List<string> GetInventoryItems()
    {
        Debug.Log("Inventory is saved");
        inventoryItems.Clear();
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
                string itemName = slots[i].transform.GetChild(0).gameObject.name.Replace("(Clone)", "").Trim();
                inventoryItems.Add(itemName);
            }
        }
        return inventoryItems;
    }
    public void SetInventoryItems(List<string> items)
    {
        ClearInventory();
        Debug.Log("Inventory is set");
        foreach (string itemName in items)
        {
            GameObject itemPrefab = Resources.Load<GameObject>(itemName);
            if (itemPrefab != null)
            {
                AddItem(itemPrefab);
            }
        }
    }
}
