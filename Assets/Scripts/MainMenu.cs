using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;
    private GameManager gameManager;
    [SerializeField] GameObject saveLoad;
     void Start()
    {
        gameManager = GameManager.instance;
    }
    public void PlayGame(){
        SceneTransitionManager.instance.SaveSceneIndex();
        gameManager.StartNewGame();
    }

    //Note: add buttons for start and load here future me
    public void QuiteGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
    public void OpenSaveLoadPanel(){
        saveLoad.SetActive(true);
    }
}