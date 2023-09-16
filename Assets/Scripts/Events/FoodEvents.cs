using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEvents
{
    public event Action onFoodCollected;
    public void FoodCollected()
    {
        if (onFoodCollected != null)
        {
            onFoodCollected();
        }
    }
}
