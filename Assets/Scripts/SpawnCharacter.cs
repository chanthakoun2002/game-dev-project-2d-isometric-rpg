using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    public int incomingIndex;
    public bool defaultSpawn;//default spawn on a spawn point if code messes up just spawn at default

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, quaternion.identity);
        player.transform.SetParent(transform);
    }
}
