using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1 food -> 20 experience
// 100 experience -> 1 level
//+1 level -> unlock one diary

public class PlayerLevelManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingLevel = 0;
    [SerializeField] private int startingExperience = 0;

    private int currentLevel;
    private int currentExperience;

    private void Awake()
    {
        currentLevel= startingLevel;
        currentExperience = startingExperience;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onExperienceGained += ExperienceGained;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onExperienceGained -= ExperienceGained;
    }

    private void Start()
    {
        GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
        GameEventsManager.instance.playerEvents.PlayerExperienceChange(currentExperience);
    }

    private void ExperienceGained(int experience)
    {
        currentExperience += experience;
        Debug.Log("Current Ex: " + currentExperience);
        // check if we're ready to level up
        while (currentExperience >= GlobalConstants.experienceToLevelUp)
        {
            currentExperience -= GlobalConstants.experienceToLevelUp;
            currentLevel++;
            Debug.Log("Level up, current level: " + currentLevel);
            GameEventsManager.instance.playerEvents.PlayerLevelChange(currentLevel);
        }
        GameEventsManager.instance.playerEvents.PlayerExperienceChange(currentExperience);
    }
}
