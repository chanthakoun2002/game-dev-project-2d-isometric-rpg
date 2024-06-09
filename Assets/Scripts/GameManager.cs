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
        SceneManager.LoadScene(1); // Load the main game scene
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

}