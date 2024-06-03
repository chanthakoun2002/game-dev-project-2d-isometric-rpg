using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveLoadSlotManager : MonoBehaviour
{
    public int slotNumber;
    public Text statusText; 
    [SerializeField] GameObject saveLoad;
    [SerializeField] GameObject pauseMenu;

    private string GetFilePath()
    {
        return Application.persistentDataPath + "/GameData" + slotNumber + ".json";
    }

    private void Start()
    {
        UpdateSlotStatus();
    }
    
    public void UpdateSlotStatus()
    {
        string filePath = GetFilePath();
        if (File.Exists(filePath))
        {
            DateTime lastWriteTime = File.GetLastWriteTime(filePath);
            statusText.text = "Saved: " + lastWriteTime.ToString("g");
        }
        else
        {
            statusText.text = "Empty";
        }
    }
    public void SaveGame()
    {
        PlayerData.SaveToJson(slotNumber);
        Debug.Log($"Game saved in slot {slotNumber}");
        UpdateSlotStatus();
    }

    public void LoadGame()
    {
        string filePath = GetFilePath();
        if (File.Exists(filePath))
        {
            PlayerData.LoadFromJson(slotNumber);
            Debug.Log($"Game loaded from slot {slotNumber}");
            saveLoad.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Debug.Log($"No save file found in slot {slotNumber}");
            statusText.text = "No Save Found";
        }
    }

    public void DeleteSave()
    {
        PlayerData.DeleteSave(slotNumber);
        Debug.Log($"Save deleted from slot {slotNumber}");
        UpdateSlotStatus();
    }
    public void Exit(){
        saveLoad.SetActive(false);
    }
}
