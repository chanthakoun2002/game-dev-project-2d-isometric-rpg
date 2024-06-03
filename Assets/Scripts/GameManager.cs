using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int defaultPlayerHealth = 100; //default player health value
    public static GameManager instance;

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
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1); // Load the main gameplay scene
        ClearGameData();
    }

    public void ClearGameData()
    {
        //clear or default all the data
        PlayerData.SavePlayerHealth(defaultPlayerHealth);
        Inventory.instance.ClearInventory();
        KillCount.instance.DefaultScore();
    }

    public void ExitGame()
    {
        ClearGameData();
        Application.Quit();
    }
    // public void SetPlayerDataAfterSceneLoad(GameData data)
    // {
    //     StartCoroutine(SetPlayerDataCoroutine(data));
    // }

    // private IEnumerator SetPlayerDataCoroutine(GameData data)
    // {
    //     while (GameObject.FindGameObjectWithTag("Player") == null)
    //         yield return null;

    //     GameObject player = GameObject.FindGameObjectWithTag("Player");
    //     player.transform.position = data.playerPosition;
    //     Inventory.instance.SetInventoryItems(data.inventoryItems);
    //     Debug.Log("Player data set after scene load.");
    // }
}