using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void spawnDroppedItem(){
        Vector2 playerPos = new(player.position.x, player.position.y  + 1);
        
        Instantiate(item, playerPos, Quaternion.identity);
        Debug.Log("New item has Spawned");
    }
}
