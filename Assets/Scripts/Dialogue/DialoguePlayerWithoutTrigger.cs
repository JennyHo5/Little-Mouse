using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayerWithoutTrigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    

    private void Update()
    {
        //if dialogue is NOT playing
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON, null);
        }
    }
}
