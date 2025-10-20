using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject UIContainer;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null && !NPCInteractable.isDialogueActive)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(IInteractable interactable)
    {
        UIContainer.SetActive(true);
        interactText.text = interactable.GetInteractText();
    }

    private void Hide()
    {
        UIContainer.SetActive(false);
    }
}
