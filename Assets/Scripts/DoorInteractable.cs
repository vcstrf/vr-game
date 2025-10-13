using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;

    public string GetInteractText()
    {
        return interactText;
    }

    public void Interact()
    {
        // door logic
        Debug.Log("interacted with door");
    }

    public Transform GetTransform()
    {
        return transform;
    }
}

