using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Pause");
    }
    public void Menu(){
        SceneManager.LoadScene(0); //main menu
        Time.timeScale = 1;
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Save(){
        //
    }
    public void Load(){
        //
    }
}
