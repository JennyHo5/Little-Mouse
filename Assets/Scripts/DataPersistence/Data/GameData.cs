using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int foodCount;

    //the value defined in this constructor will be the default values
    //the game starts with when there's no data to load
    public GameData()
    {
        this.foodCount = 0;
    }
}
