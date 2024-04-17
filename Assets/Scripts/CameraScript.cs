using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   public Transform player;
    public Vector3 offset;
    void Update () 
    {
        //will allow game camera to follow the player
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); 
    }
}
