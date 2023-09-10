using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FoodCollectible : MonoBehaviour, IDataPersistence
{
    [Header("Config")]
    [SerializeField] private int foodGained = 1;
    private BoxCollider2D boxCollider;
    private SpriteRenderer visual;

    private bool collected = false;

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        visual= GetComponentInChildren<SpriteRenderer>();
    }

    public void LoadData(GameData data)
    {
        data.foodsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            boxCollider.enabled = false;
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.foodsCollected.ContainsKey(id))
        {
            data.foodsCollected.Remove(id);
        }
        data.foodsCollected.Add(id, collected);
    }

    private void CollectFood()
    {
        boxCollider.enabled= false;
        visual.gameObject.SetActive(false);
        collected = true;
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
