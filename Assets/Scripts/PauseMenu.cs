using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject saveLoad;
    [SerializeField] GameObject gameOverScreen;

    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game Pause");
    }
    public void Menu(){
        
        //when this is clicked this should also clear game data when exiting to main
        GameManager.instance.ClearGameData();
        Time.timeScale = 1;
        SceneManager.LoadScene(0); //main menu
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenSaveLoadPanel(){
        saveLoad.SetActive(true);
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    // public void Save()
    // {
    //     PlayerData.SaveToJson();
    //     Debug.Log("Game data saved to JSON.");
    //     Time.timeScale = 1;
    //     //pauseMenu.SetActive(false);
    // }
    // public void Load()
    // {
    //     PlayerData.LoadFromJson();
    //     Debug.Log("Game data loaded from JSON.");
    //     Time.timeScale = 1;
    //     //pauseMenu.SetActive(false);
    // }
}
