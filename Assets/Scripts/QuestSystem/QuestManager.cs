using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour, IDataPersistence
{
    private bool loadQuestState = true;
    [SerializeField] private Dictionary<string, Quest> questMap;

    //quest start requirement
    private int currentPlayerLevel;

    private void Awake()
    {
        questMap = InitializeQuestMap();
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += FinishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange += QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= StartQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= AdvanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= FinishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange -= QuestStepStateChange;

        GameEventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;

    }

    private void Start()
    {
        //boardcast the initial state of all quests on startup
        foreach (Quest quest in questMap.Values)
        {
            //initalize any loaded quest steps
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.InstantiateCurrentQuestStep(this.transform);
            }
            //boardcast the initial state of all quests on startup
            GameEventsManager.instance.questEvents.QuestStateChange(quest);
        }
    }

    private void ChangeQuestState(string id, QuestState state)
    {
        Quest quest = GetQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.QuestStateChange(quest); //send out an event indicating the quest state has been changed
    }

    private bool CheckRequirementMet(Quest quest)
    {
        bool meetRequirements = true;

        //check player level requirements
        if (currentPlayerLevel < quest.info.levelRequirement)
        {
            meetRequirements = false;
        }

        //check quest prerequisites for completion
        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisities)
        {
            if (GetQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED)
            {
                meetRequirements = false;
            }
        }

        return meetRequirements;
    }

    private void Update()
    {
        //loop through all quests
        foreach (Quest quest in questMap.Values)
        {
            //if we're now meeting the requirements, switch over to the CAN_START state
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementMet(quest))
            {
                ChangeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }

    private void PlayerLevelChange(int level)
    {
        currentPlayerLevel = level;
    }

    private void StartQuest(string id)
    {
        Debug.Log("Start Quest: " + id);
        Quest quest = GetQuestById(id);
        quest.InstantiateCurrentQuestStep(this.transform);
        ChangeQuestState(quest.info.id, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(string id)
    {
        Debug.Log("Advance Quest: " + id);
        Quest quest = GetQuestById(id);
        //move on to the next step
        quest.MoveToNextStep();

        //if there are more steps, instantiate the next one
        if (quest.CurrentStepExists())
        {
            quest.InstantiateCurrentQuestStep(this.transform);
        }
        //if there are no more quests, then we've finished all of them for this quest
        else
        {
            ChangeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }

    private void FinishQuest(string id)
    {
        Debug.Log("Finished Quest: " + id);
        Quest quest = GetQuestById(id);
        ClaimRewards(quest);
        ChangeQuestState(quest.info.id, QuestState.FINISHED);
    }

    private void ClaimRewards(Quest quest)
    {
        //TODO: claim reward
        Debug.Log("Got reward from quest " + quest.info.id + ": " + quest.info.questRewardItem);
    }

    private void QuestStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = GetQuestById(id);
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(id, quest.state);
        Debug.Log("Quest " + id + " changed to state " + quest.state);
    }

    private Quest GetQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null)
        {
            Debug.LogError("ID not found in the Quest Map: " + id);
        }
        return quest;
    }

    private Dictionary<string, Quest> InitializeQuestMap()
    {
        Debug.Log("Initalizing the questMap...");
        //loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        //create the quest map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questinfo in allQuests)
        {
            Debug.Log("For quest: " + questinfo.id);
            if (idToQuestMap.ContainsKey(questinfo.id))
            {
                Debug.LogWarning("Duplicate ID found when creating quest map:" + questinfo.id);
            }
            Quest quest = new Quest(questinfo); //initialized a new quest
            idToQuestMap.Add(questinfo.id, quest);
        }
        return idToQuestMap;
    }


    private Dictionary<string, Quest> CreateQuestMap(Dictionary<string, QuestData> questMap2)
    {
        //loads all QuestInfoSO Scriptable Objects under the Assets/Resources/Quests folder
        QuestInfoSO[] allQuests = Resources.LoadAll<QuestInfoSO>("Quests");
        //create the quest map
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questinfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questinfo.id))
            {
                Debug.LogWarning("Duplicate ID found when creating quest map:" + questinfo.id);
            }
            idToQuestMap.Add(questinfo.id, LoadQuest(questinfo, questMap2));
        }
        return idToQuestMap;
    }


    private Quest LoadQuest(QuestInfoSO questInfo, Dictionary<string, QuestData> questData1)
    {
        Quest quest = null;
        try
        {
            //load quest from saved data
            if (questData1.ContainsKey(questInfo.id) && loadQuestState)
            {
                QuestData questEntry = questData1[questInfo.id];
                quest = new Quest(questInfo, questEntry.state, questEntry.questStepIndex, questEntry.questStepStates);
            }
            //otherwise initialized a new quest
            else
            {
                quest = new Quest(questInfo);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load quest with id " + quest.info.id + ": " + e);
        }
        return quest;
    }


    public void SaveData(ref GameData data)
    {

        foreach (Quest quest in questMap.Values)
        {
            try
            {
                QuestData questData = quest.GetQuestData();

                Debug.Log("For quest " + quest.info.id);
                Debug.Log("Trying to save questData.questStepIndex: " + questData.questStepIndex);
                Debug.Log("Trying to save questData.questStepStates: ");
                for (int i = 0; i < questData.questStepStates.Length; i++)
                {
                    Debug.Log(questData.questStepStates[i].state);
                }

                if (data.questMap.ContainsKey(quest.info.id))
                {
                    data.questMap.Remove(quest.info.id);
                }
                data.questMap.Add(quest.info.id, questData);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to save quest with id " + quest.info.id + ": " + e);
            }
        }
    }

    public void LoadData(GameData data)
    {
        Debug.Log("Loading quest map from data.game ...");
        questMap = CreateQuestMap(data.questMap);
    }

    private void OnApplicationQuit()
    {
        foreach (Quest quest in questMap.Values)
        {
            QuestData questData = quest.GetQuestData();
            Debug.Log(quest.info.id);
            Debug.Log("state = " + questData.state);
            Debug.Log("index = " + questData.questStepIndex);
            foreach (QuestStepState stepState in questData.questStepStates)
            {
                Debug.Log("step state = " + stepState.state);
            }
        }
    }
}
