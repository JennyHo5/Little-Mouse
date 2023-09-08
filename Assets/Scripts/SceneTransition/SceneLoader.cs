using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool playerInRange;

    [Header("Transition")]
    [SerializeField] private Animator transition;
    [Header("Transition Time")]
    [SerializeField] private float transitionTime = 1.0f;

    [Header("Next Scene Index")]
    [SerializeField] private int sceneIndex;

    private void Awake()
    {
        playerInRange= false;
    }

    void Update()
    {
        if (playerInRange)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(sceneIndex)); //load to the scene index in "Scenes in build"
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        //play animation
        transition.SetTrigger("Start"); //set trigger as "start" parameter in animator

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
