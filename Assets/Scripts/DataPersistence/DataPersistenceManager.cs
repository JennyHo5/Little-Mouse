using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistence in the scene.");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //TODO: load any saved data from a file using the data handler
        //if no data to load, initialize to a new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaluts.");
            NewGame();
        }
        //TODO: push the loaded data to all other scripts that need it
    }

    public void SaveGame()
    {
        //TODO: pass the data to other scripts so they can update it
        //TODO: save that data to a file using the data handler
    }
}
