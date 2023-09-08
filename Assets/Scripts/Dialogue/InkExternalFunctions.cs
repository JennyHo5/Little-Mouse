using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{

    public void Bind(Story story, Animator itemAnimator)
    {
        //start listening for calls to that playItemAnim function whenever that's called in the current story
        story.BindExternalFunction("playItemAnim", (string itemAnim) => PlayItemAnim(itemAnim, itemAnimator));
        story.BindExternalFunction("startQuest", (string questId) => StartQuest(questId));
        story.BindExternalFunction("updateQuest", (string questId) => UpdateQuest(questId));
        story.BindExternalFunction("finishQuest", (string questId) => FinishQuest(questId));
        story.BindExternalFunction("takeItem", (string itemName) => TakeItem(itemName));
    }

    public void UnBind(Story story)
    {
        //unbind the function
        story.UnbindExternalFunction("playItemAnim");
        story.UnbindExternalFunction("startQuest");
        story.UnbindExternalFunction("updateQuest");
        story.UnbindExternalFunction("finishQuest");
        story.UnbindExternalFunction("takeItem");
    }

    public void PlayItemAnim(string itemAnim, Animator itemAnimator) {
        if (itemAnim != null)
        {
            itemAnimator.Play(itemAnim);
        }
        else
        {
            Debug.LogWarning("Tried to play animation, but item animator was not initialized when entering dialogue mode.");
        }
    }

    public void TakeItem(string itemName) {
        GameObject item = GameObject.Find(itemName);
        if (item != null)
        {
            item.SetActive(false);
        } else
        {
            Debug.LogWarning("Game Object with name " + itemName + "not found.");
        }
    }

    public void StartQuest(string questId)
    {
        Debug.Log("Start quest " + questId);
        GameEventsManager.instance.questEvents.StartQuest(questId);
    }

    public void UpdateQuest(string questId) 
    {
        Debug.Log("Update quest " + questId);
        GameEventsManager.instance.questEvents.AdvanceQuest(questId);
    }

    public void FinishQuest(string questId)
    {
        Debug.Log("Finish quest " + questId);
        GameEventsManager.instance.questEvents.FinishQuest(questId);
    }

}
