using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //save foot count
    public int foodCount;
    //save player's position
    public Vector3 playerPosition;
    //save which food have been collected
    public SerializableDictionary<string, bool> foodsCollected;

    //the value defined in this constructor will be the default values
    //the game starts with when there's no data to load
    public GameData()
    {
        this.foodCount = 0;
        playerPosition = new Vector3(-2, -1, 0);
        foodsCollected = new SerializableDictionary<string, bool>();
    }
}
