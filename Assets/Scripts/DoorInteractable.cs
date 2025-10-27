using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    [SerializeField] private bool activatesQuest;
    [SerializeField] private string debugText;
    public Quest previousQuest;
    public Quest quest;

    public string GetInteractText()
    {
        return interactText;
    }

    public void Interact()
    {
        if (QuestController.questsStack.Contains(previousQuest.questID))
        {
            // door logic
            Debug.Log("interacted with door");
            if (quest != null && activatesQuest && !QuestController.questsStack.Contains(quest.questID))
            {
                QuestController.instance.ActivateNewQuest(quest);
            }
        }
        else
        {
            Debug.Log(debugText);
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public bool ActivatesQuest()
    {
        return activatesQuest;
    }
}

