using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Scriptable Objects/Quest")]
public class Quest : ScriptableObject
{
    public string questID;
    public string questText;
    public QuestType type;
    public bool isCompleted;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(questID))
        {
            questID = Guid.NewGuid().ToString();
        }
    }

    public enum QuestType
    {
        ReachLocation, Interact, DialogueOption
    }
}
