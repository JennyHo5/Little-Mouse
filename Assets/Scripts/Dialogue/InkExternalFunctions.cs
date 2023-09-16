using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        story.BindExternalFunction("showItem", (string itemName) => ShowItem(itemName));
        story.BindExternalFunction("putInInventory", (string itemName) => PutInInventory(itemName));
        story.BindExternalFunction("takeOutInventory", (string itemName) => TakeOutInventory(itemName));
    }

    public void UnBind(Story story)
    {
        //unbind the function
        story.UnbindExternalFunction("playItemAnim");
        story.UnbindExternalFunction("startQuest");
        story.UnbindExternalFunction("updateQuest");
        story.UnbindExternalFunction("finishQuest");
        story.UnbindExternalFunction("takeItem");
        story.UnbindExternalFunction("showItem");
        story.UnbindExternalFunction("putInInventory");
        story.UnbindExternalFunction("takeOutInventory");
    }

    public void PutInInventory(string itemName)
    {
        GameObject inventory = GameObject.Find("Inventory");
        GameObject item = inventory.transform.Find(itemName).gameObject;
        if (item != null)
        {
            item.SetActive(true);
        } else
        {
            Debug.LogError("Cannot find item " + itemName + " in the inventory.");
        }
    }

    public void TakeOutInventory(string itemName)
    {
        GameObject inventory = GameObject.Find("Inventory");
        GameObject item = inventory.transform.Find(itemName).gameObject;
        if (item != null)
        {
            item.SetActive(false);

        } else
        {
            Debug.LogError("Cannot find item " + itemName + " in the inventory.");
        }
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
            Debug.LogWarning("Game Object with name " + itemName + " not found.");
        }
    }

    public void ShowItem(string itemName)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "Plunger")
            {
                obj.SetActive(true);
                break;
            }
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
