using UnityEngine;

public interface IInteractable
{
    void Interact();
    bool ActivatesQuest();
    string GetInteractText();
    Transform GetTransform();
}
