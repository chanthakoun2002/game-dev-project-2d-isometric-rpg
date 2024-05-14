using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public string playerTag = "Player";
    public Vector3 offset;

    private Transform playerTransform;

    void Update()
    {
        // Find the player object by tag if it hasn't been found yet
        if (playerTransform == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
            if (playerObject != null)
            {
                playerTransform = playerObject.transform;
            }
        }
        else
        {
            // Follow the player if it has been found
            transform.position = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z);
        }
    }
}