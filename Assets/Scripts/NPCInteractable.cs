using ElmanGameDevTools.PlayerSystem;
using System.Collections;
using TMPro;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText;
    public NPCDialogue dialogueData;
    private DialogueController dialogueController;

    public static bool isDialogueActive;
    private bool isTyping;
    private int dialogueIndex;

    private void Start()
    {
        dialogueController = DialogueController.instance;
    }

    public void Interact()
    {
        // dialogue logic
        if (isDialogueActive)
        {
            NextLine();
        }
        else
        {
            Debug.Log("interacted with npc");
            StartDialogue();
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        dialogueController.SetNPCName(dialogueData.npcName);
        dialogueController.ShowDialogueUI(true);

        DisplayCurrentLine();
        // disable movement
    }

    private void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        dialogueController.ClearChoices();

        // check endDialogueLines
        if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        // check for choices & display
        foreach (DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.dialogueIndex == dialogueIndex)
            {
                DisplayChoices(dialogueChoice);
                return;
            }
        }

        if (++dialogueIndex < dialogueData.dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueController.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            dialogueController.SetDialogueText(dialogueController.dialogueText.text += letter);
            yield return new WaitForSeconds(dialogueData.textSpeed);
        }

        isTyping = false;

        if (dialogueData.autoSkip.Length > dialogueIndex && dialogueData.autoSkip[dialogueIndex])
        {
            yield return new WaitForSeconds(dialogueData.autoSkipDelay);
            NextLine();
        }
    }

    private void DisplayChoices(DialogueChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialogueIndexes[i];
            dialogueController.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
        }
    }

    private void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        dialogueController.ClearChoices();
        DisplayCurrentLine();
    }

    private void DisplayCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueController.SetDialogueText("");
        dialogueController.ShowDialogueUI(false);
        // enable movement
    }
}
