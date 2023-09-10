using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour, IDataPersistence
{
    [Header("Configuration")]
    [SerializeField] private int startingFood = 0;

    public int currentFood { get;  private set; }

    private void Awake()
    {
        currentFood= startingFood;
    }

    public void LoadData(GameData data)
    {
        this.currentFood = data.foodCount;
    }

    public void SaveData(ref GameData data)
    {
        data.foodCount = this.currentFood;
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
