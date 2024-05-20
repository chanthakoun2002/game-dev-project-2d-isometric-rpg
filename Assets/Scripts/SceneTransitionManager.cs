using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    private Inventory inventory;

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
