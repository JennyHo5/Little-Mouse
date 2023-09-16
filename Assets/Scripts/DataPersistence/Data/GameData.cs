using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //save foot count
    public int foodCount;
    //save which food have been collected
    public SerializableDictionary<string, bool> foodsCollected;
    //save which scene is been saved
    public int sceneIndex;
    //save quests
    public SerializableDictionary<string, QuestData> questMap;

    //the value defined in this constructor will be the default values
    //the game starts with when there's no data to load
    public GameData()
    {
        this.foodCount = 0;
        this.foodsCollected = new SerializableDictionary<string, bool>();
        this.sceneIndex = 0;
        this.questMap = new SerializableDictionary<string, QuestData>();
    }
}
