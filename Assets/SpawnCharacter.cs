using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Start()
    {
        Instantiate(player, transform.position, quaternion.identity);
    }
}
