using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, transform.position, quaternion.identity);
        
        player.transform.SetParent(transform);
    }
}
