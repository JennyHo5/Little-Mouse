using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FoodCollectible : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private int foodGained = 1;
    [SerializeField] private int experienceGained = 20;

    private BoxCollider2D boxCollider;
    private SpriteRenderer visual;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        visual= GetComponentInChildren<SpriteRenderer>();
    }

    private void CollectFood()
    {
        boxCollider.enabled= false;
        visual.gameObject.SetActive(false);
        GameEventsManager.instance.playerEvents.ExperienceGained(experienceGained);
        GameEventsManager.instance.foodEvents.FoodGained(foodGained);
        GameEventsManager.instance.miscEvents.FoodCollected();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
                CollectFood();
            }
        
    }
}
