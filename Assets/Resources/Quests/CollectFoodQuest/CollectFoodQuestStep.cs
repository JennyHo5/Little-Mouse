using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFoodQuestStep : QuestStep
{
    private int foodCollected = 0;
    private int foodComplete = 5;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onFoodCollected += FoodCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onFoodCollected -= FoodCollected;
    }

    private void FoodCollected()
    {
        if (foodCollected < foodComplete)
        {
            foodCollected++;
            UpdateState();
        }
            
        

        if (foodCollected >= foodComplete)
            FinishQuestStep();
    }



    protected override void SetQuestStepState(string state)
    {
        this.foodCollected = System.Int32.Parse(state);
        UpdateState();
    }

    private void UpdateState()
    {
        string state = foodCollected.ToString();
        ChangeState(state);
    }
}
