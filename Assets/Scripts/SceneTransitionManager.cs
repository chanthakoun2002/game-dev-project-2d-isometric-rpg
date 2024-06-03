using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private Inventory inventory;
    public static SceneTransitionManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(WaitForInventory());
    }

    IEnumerator WaitForInventory()
    {
        while (inventory == null)
        {
            inventory = Inventory.instance;
            yield return null;
        }
    }
    public void SaveSceneIndex()
    {//save the build index for next scene to see
        int lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Index Saved" + lastSceneIndex);
        PlayerPrefs.SetInt("SceneIndex", lastSceneIndex);
        PlayerPrefs.Save();
    }
    public static int LoadLastIndex()
    {
        return PlayerPrefs.GetInt("SceneIndex"); //give the index of the last scene
    }

    public void ChangeScene(int sceneIndex)
    {
        if (inventory != null)
        {
            inventory.SaveInventory();
            
        }
        SceneManager.LoadScene(sceneIndex);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(LoadInventoryWhenReady());
        
    }

    IEnumerator LoadInventoryWhenReady()
    {
        yield return null;  //wait for load
        while (inventory == null)
        {
            inventory = Inventory.instance;
            yield return null;
        }
        //inventory.ClearInventory();
        inventory.LoadInventory();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
