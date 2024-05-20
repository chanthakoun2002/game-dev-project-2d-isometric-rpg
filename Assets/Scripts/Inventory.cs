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

    void Start()
    {
        //LoadInventory();
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
        PlayerPrefs.SetString("Inventory", json);
        PlayerPrefs.Save();
        Debug.Log("Inventory saved: " + json);
    }

    public void LoadInventory()
    {
        //ClearInventory();//clear out old inventory
        if (PlayerPrefs.HasKey("Inventory"))
        {
            string json = PlayerPrefs.GetString("Inventory");
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
        Debug.Log("Inventory loaded: " + PlayerPrefs.GetString("Inventory"));
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
        PlayerPrefs.DeleteKey("Inventory");
    }
}
