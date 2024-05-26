using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int defaultPlayerHealth = 100; //default player health value
    public KillCount KillCount;
    private Inventory inventory;

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
    void Start()
    {

        // Reset player health to the default value when the game starts
        //PlayerData.SavePlayerHealth(defaultPlayerHealth);

        //Inventory.instance.ClearInventory();
        //StartNewGame();//no matter where game is started it will start at the main menu
    }

    public void StartNewGame()//might change later
    {
        PlayerData.SavePlayerHealth(defaultPlayerHealth);
        Inventory.instance.ClearInventory();
        SceneManager.LoadScene(0);
        KillCount.defaultScore();
    }
}