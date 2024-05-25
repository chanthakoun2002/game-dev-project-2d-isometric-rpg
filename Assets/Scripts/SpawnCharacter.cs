using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public int incomingIndex;
    public bool defaultSpawn;//defautl spawn on a spawn point if code messes up just spawn at default
    //private SceneTransitionManager TransitionManager;

    

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        //SpawnPlayer();

        int lastIndex = SceneTransitionManager.LoadLastIndex();
        
        
        if(incomingIndex == lastIndex){
            SpawnPlayer();
            Debug.Log("Spawned At " + gameObject.name);
            
        }
        else if(defaultSpawn){// this default messes up spawns in certain scenes //NOT WORKING CORRECTLY ON MAIN SCENE
            SpawnPlayer();
            Debug.Log("Spawned at default");
        }
    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, quaternion.identity);
        
        player.transform.SetParent(transform);
    }
}
