using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public Quest quest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateQuestUI(quest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateQuestUI(Quest quest)
    {
        QuestController.questsStack.Push(quest.questID);
        questText.text = quest.questText;
    }
}
