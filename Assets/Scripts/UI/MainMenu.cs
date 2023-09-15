using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
    }
    public void PlayGame()
    {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("BathroomScene");
    }


    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
        //load the scene, which will in turn save the game because of OnSceneUnloaded() in theDataPersistenceManager
        SceneManager.LoadScene(DataPersistenceManager.instance.gameData.sceneIndex);
    }

    public void OnApplicationQuit()
    {
        DataPersistenceManager.instance.SaveGame();
        Debug.Log("Saved and Quited the game.");
        Application.Quit();
    }
}
