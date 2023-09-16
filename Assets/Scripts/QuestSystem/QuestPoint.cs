using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class QuestPoint : MonoBehaviour
{

    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("QuestIcon")]
    [SerializeField] private GameObject questIcon;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset startPointDialogue;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset finishPointDialogue;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;


    private bool playerIsNear = false;

    private string questId;

    private QuestState currentQuestState;

    private void Awake()
    {
        questId = questInfoForPoint.id;
        questIcon.SetActive(false);
    }

    private void Update()
    {
        //if player is in range and dialogue is NOT playing
        if (playerIsNear && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            questIcon.SetActive(true);
            if (InputManager.GetInstance().GetSubmitPressed())
            {
                if (finishPoint && currentQuestState == QuestState.FINISHED)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(finishPointDialogue, null);
                } else if (startPoint)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(startPointDialogue, null);
                }
            }
        }
        else
        {
            questIcon.SetActive(false);
        }
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += QuestStateChange;
        GameEventsManager.instance.inputEvents.onSubmitPressed += SubmitPressed;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= QuestStateChange;
        GameEventsManager.instance.inputEvents.onSubmitPressed -= SubmitPressed;
    }

    private void SubmitPressed()
    {
        if (!playerIsNear)
        {
            return;
        }

        //start or finish a quest
        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.StartQuest(questId);
        }
        else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventsManager.instance.questEvents.FinishQuest(questId);
        }
    }

    private void QuestStateChange(Quest quest)
    {
        //only update the quest state if this point has the corresponding quest
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
            Debug.Log("Quest with id: " + questId + " updated to state: " + currentQuestState + " with quest step index " + quest.GetQuestData().questStepIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }

}
