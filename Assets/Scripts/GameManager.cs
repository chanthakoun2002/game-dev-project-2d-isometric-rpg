using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int defaultPlayerHealth = 100; //default player health value

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
        PlayerData.SavePlayerHealth(defaultPlayerHealth);

        //Inventory.instance.ClearInventory();
    }

    public void StartNewGame()//might change later
    {
        //reset player health to the default value
        PlayerData.SavePlayerHealth(defaultPlayerHealth);

        //clear the inventory for new game
        Inventory.instance.ClearInventory();

        //load the first level or main menu scene
        SceneManager.LoadScene(0);
    }
}