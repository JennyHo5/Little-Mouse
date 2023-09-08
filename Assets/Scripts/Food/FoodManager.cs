using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingFood = 0;

    public int currentFood { get;  private set; }

    private void Awake()
    {
        currentFood= startingFood;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.foodEvents.onFoodGained += FoodGained;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.foodEvents.onFoodGained -= FoodGained;
    }

    private void Start()
    {
        GameEventsManager.instance.foodEvents.FoodChange(currentFood);
    }

    private void FoodGained(int food)
    {
        currentFood += food;
        GameEventsManager.instance.foodEvents.FoodChange(currentFood);
    }
}
