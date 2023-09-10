using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Saved the game.");
        DataPersistenceManager.instance.SaveGame();
        Debug.Log("Quited the game.");
        Application.Quit();
    }

    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
