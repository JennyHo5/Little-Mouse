using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICollectivesNumber : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private TextMeshProUGUI collectiblesText;

    private void OnEnable()
    {
        GameEventsManager.instance.foodEvents.onFoodChange += FoodChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.foodEvents.onFoodChange -= FoodChange;
    }

    private void FoodChange(int food)
    {
        collectiblesText.text = "X " + food.ToString();
    }
}
