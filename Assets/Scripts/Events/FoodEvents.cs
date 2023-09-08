using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEvents
{
    public event Action<int> onFoodGained;
    public void FoodGained(int food)
    {
        if (onFoodGained != null)
        {
            onFoodGained(food);
        }
    }

    public event Action<int> onFoodChange;
    public void FoodChange(int food)
    {
        if (onFoodChange != null)
        {
            onFoodChange(food);
        }
    }
}
