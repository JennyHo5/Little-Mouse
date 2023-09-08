using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestIcon : MonoBehaviour
{
    [Header("Icons")]

    [SerializeField] private GameObject canStartIcon;
    [SerializeField] private GameObject canFinishIcon;
    private bool playerInRange;
    private QuestState currentQuestState;

    private void Awake()
    {
        playerInRange = false;
        //set all to inactive
        canStartIcon.SetActive(false);
        canFinishIcon.SetActive(false);
        currentQuestState = GetComponentInParent<QuestState>();
    }

    private void Update() 
    {
        if (playerInRange)
        {
            SetState(currentQuestState);

        }
    }
    public void SetState(QuestState newState)
    {
            if (newState == QuestState.CAN_FINISH)
            {
            canStartIcon.SetActive(false);
            canFinishIcon.SetActive(true);
            } else
            {
            canStartIcon.SetActive(true);
            canFinishIcon.SetActive(false);
           }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
