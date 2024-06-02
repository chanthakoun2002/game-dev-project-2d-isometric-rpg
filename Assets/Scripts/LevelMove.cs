using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;

    private SceneTransitionManager sceneTransitionManager;

    private void Start()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (sceneTransitionManager != null)
            {
                sceneTransitionManager.ChangeScene(sceneBuildIndex);
                sceneTransitionManager.SaveSceneIndex();
                
            }
            else
            {
                Debug.LogError("SceneTransitionManager not found or other error.");
            }
        }
    }
}