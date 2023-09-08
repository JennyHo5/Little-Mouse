using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents
{
    public event Action onRightChoiceSelected;
    public void RightChoiceSelected()
    {
        if (onRightChoiceSelected != null)
        {
            onRightChoiceSelected();
        }
    }
}
