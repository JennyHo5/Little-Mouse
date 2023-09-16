using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptableObjects/QuestInfoSO", order = 1 )]
public class QuestInfoSO : ScriptableObject
{
    [field: SerializeField] public string id { get; private set; } //reference each quest in the system

    [Header("General")]
    public string displayName;

    [Header("Requirements")]
    public int levelRequirement;
    public QuestInfoSO[] questPrerequisities;

    [Header("Steps")]
    public GameObject[] questStepPrefabs;

    [Header("Rewards")]
    public string questRewardItem;

    //ensure the id is always the name of the Scriptable Object name
    private void OnValidate() //this method will be called automatically by Unity whenever the script's properties are modified in the Inspector
    {
    #if UNITY_EDITOR // starts a conditional compilation block, which checks if the code is being executed within the Unity Editor
        id = this.name;
        UnityEditor.EditorUtility.SetDirty( this ); //its serialized data has been modified and needs to be saved
    #endif
    }
}
