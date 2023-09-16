using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICollectivesNumber : MonoBehaviour, IDataPersistence
{
    [Header("Components")]
    [SerializeField]private TextMeshProUGUI collectiblesText;

    private int foodCollected = 0;

    private void Start()
    {
        GameEventsManager.instance.foodEvents.onFoodCollected += OnFoodCollected;
    }

    private void OnDistroy()
    {
        GameEventsManager.instance.foodEvents.onFoodCollected -= OnFoodCollected;
    }

    private void Update()
    {
        collectiblesText.text = "X " + foodCollected.ToString();
    }

    public void LoadData(GameData data)
    {
        foreach(KeyValuePair<string, bool> pair in data.foodsCollected)
        {
            if (pair.Value)
            {
                foodCollected++;
            }
        } 
    }

    public void SaveData(ref GameData data)
    {
        // no data needs to be saved for this script
    }

    private void OnFoodCollected()
    {
        foodCollected++;
    }
}
