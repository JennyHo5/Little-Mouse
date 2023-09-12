using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        DataPersistenceManager.instance.NewGame();
        //clear saved data
        string filePath = Path.Combine(Application.persistentDataPath, "data.game");
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);

                Debug.Log("Data file 'data.game' has been cleaned.");
            }
            else
            {
                Debug.LogWarning("Data file 'data.game' does not exist, so nothing to clean.");
            }
        }
        catch (IOException e)
        {
            Debug.LogError($"An error occurred while cleaning the data file: {e}");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnApplicationQuit()
    {
        DataPersistenceManager.instance.SaveGame();
        Debug.Log("Saved and Quited the game.");
        Application.Quit();
    }

    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
