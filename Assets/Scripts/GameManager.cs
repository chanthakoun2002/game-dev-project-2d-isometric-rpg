using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int defaultPlayerHealth = 100; // Default player health value

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager objects
        }
    }
    void Start()
    {
        // Reset player health to the default value when the game starts
        PlayerData.SavePlayerHealth(defaultPlayerHealth);
    }

    public void StartNewGame()
    {
        // Reset player health to the default value
        PlayerData.SavePlayerHealth(defaultPlayerHealth);

        // Load the first level or main menu scene
        SceneManager.LoadScene(0);
    }
}