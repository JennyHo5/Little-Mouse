using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI levelText;

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onPlayerLevelChange += PlayerLevelChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onPlayerLevelChange -= PlayerLevelChange;
    }

    private void PlayerLevelChange(int level)
    {
        levelText.text = "Level: " + level;
    }
}
