using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        //will load next scene in the build list
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    //Note: add buttons for start and load here future me
    public void QuiteGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}