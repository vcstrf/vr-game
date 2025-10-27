using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController instance {  get; private set; }
    public static Stack<string> questsStack;
    private QuestUI questUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        questsStack = new Stack<string>();

        questUI = FindFirstObjectByType<QuestUI>();
    }

    public void ActivateNewQuest(Quest quest)
    {
        questUI.UpdateQuestUI(quest);
    }
}
