using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Save player health to PlayerPrefs
    public static void SavePlayerHealth(int health)
    {
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.Save();
    }

    // Load player health from PlayerPrefs
    public static int LoadPlayerHealth()
    {
        return PlayerPrefs.GetInt("PlayerHealth", 100);
    }
}
