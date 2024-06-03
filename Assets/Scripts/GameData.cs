using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData //data model
{
    public int health;
    public int score;
    public Vector2 playerPosition;
    public List<string> inventoryItems;
    public int sceneIndex;
}
