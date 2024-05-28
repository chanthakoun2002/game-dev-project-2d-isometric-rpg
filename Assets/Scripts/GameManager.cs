using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int defaultPlayerHealth = 100; //default player health value
    //private Inventory inventory;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); //destroy duplicate GameManager objects
        }
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
        ClearGameData();//if any data left remaining that is carried to main scene it will clear out when new game is started
    }

    public void ClearGameData()
    {
        //clears out the data of the player
        PlayerData.SavePlayerHealth(defaultPlayerHealth);
        if (Inventory.instance != null)
        {
            Inventory.instance.ClearInventory();
        }
        else
        {
            Debug.LogWarning("Inventory instance is null. Cannot clear inventory.");
        }
        if (KillCount.instance != null)
        {
            KillCount.instance.DefaultScore();
        }
        else
        {
            Debug.LogWarning("KillCount instance is null. Cannot reset score.");
        }
    }
    public void ExitGame()
    {
        //clean up any ongoing game data
        ClearGameData();
        //exit the application
        Application.Quit();
    }
}