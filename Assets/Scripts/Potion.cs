using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion", menuName = "Items/Health Potion")]
public class Potion : ScriptableObject
{
    public int healthRestored;
}