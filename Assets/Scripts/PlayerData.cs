using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    private const string PlayerHealthKey = "PlayerHealth";
    private const string PlayerScoreKey = "PlayerScore";
    //private const string SceneIndexKey = "SceneIndex"; //not using this
    public const string InventoryKey = "Inventory";
    private static string BaseFilePath = Application.persistentDataPath + "/GameData";


    //data handling for scene to scene
    public static void SavePlayerHealth(int health)
    {
        PlayerPrefs.SetInt(PlayerHealthKey, health);
        PlayerPrefs.Save();
    }

    public static void SavePlayerScore(int score)
    {
        PlayerPrefs.SetInt(PlayerScoreKey, score);
        PlayerPrefs.Save();
    }
    public static int LoadPlayerHealth()
    {
        return PlayerPrefs.GetInt(PlayerHealthKey, 100);
    }

    public static int LoadPlayerScore()
    {
        return PlayerPrefs.GetInt(PlayerScoreKey, 0);
    }
    //Note: load/save inventory is being handled in the inventory script


    //handling for saving to json and loading from json file
    public static void SaveToJson(int slot)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = player.transform.position;
        GameData data = new GameData{
            health = LoadPlayerHealth(),
            score = LoadPlayerScore(),
            playerPosition = playerPosition,
            inventoryItems = Inventory.instance.GetInventoryItems(),
            sceneIndex = SceneManager.GetActiveScene().buildIndex
        };
        string filePath = $"{BaseFilePath}{slot}.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log($"Data saved to JSON in Slot {slot}: {json}");
    }
    public static void LoadFromJson(int slot){
        string filePath = $"{BaseFilePath}{slot}.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            SceneManager.LoadScene(data.sceneIndex, LoadSceneMode.Single);
            SceneManager.sceneLoaded += OnSceneLoaded;

            void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = data.playerPosition;
                Inventory.instance.SetInventoryItems(data.inventoryItems);
                SceneManager.sceneLoaded -= OnSceneLoaded;
                Debug.Log("Scene loaded and data applied.");
            }
            PlayerPrefs.SetInt(PlayerHealthKey, data.health);
            PlayerPrefs.SetInt(PlayerScoreKey, data.score);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("No save file found.");
        }
    }
    public static void DeleteSave(int slot){
        string filePath = $"{BaseFilePath}{slot}.json";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log($"Deleted save file in slot: {slot}");
        }
        else
        {
            Debug.LogError($"No save file found to delete in slot: {slot}");
        }
    }
}
