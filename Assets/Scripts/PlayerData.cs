using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Save player health/data to PlayerPrefs
    public static void SavePlayerHealth(int health)
    {
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }
    public static void SavePlayerScore(int score){
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }


    // Load player health/data from PlayerPrefs
    public static int LoadPlayerHealth()
    {
        return PlayerPrefs.GetInt("PlayerHealth", 100);//default to full health if not found
    }
    public static int LoadPlayerScore()
    {
        return PlayerPrefs.GetInt("PlayerScore", 0);
    }
}
