using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    void Awake()//this has to be awake if not spawning player data from load json will not work correctly
    {

        SpawnCharacter[] spawnPoints = FindObjectsOfType<SpawnCharacter>();
        int lastIndex = SceneTransitionManager.LoadLastIndex();
        bool spawned = false;

        foreach (var spawnPoint in spawnPoints)
        {
            if (spawnPoint.incomingIndex == lastIndex)
            {
                spawnPoint.SpawnPlayer();
                Debug.Log("Spawned at: " + spawnPoint.gameObject.name);
                spawned = true;
                break;
            }
        }

        if (!spawned)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                if (spawnPoint.defaultSpawn)
                {
                    spawnPoint.SpawnPlayer();
                    Debug.Log("Spawned at default location: " + spawnPoint.gameObject.name);
                    break;
                }
            }
        }
    }
}
