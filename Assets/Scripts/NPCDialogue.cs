using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogue", menuName = "Scriptable Objects/NPCDialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public string[] dialogueLines;
    public float textSpeed = 0.05f;
    public bool[] autoSkip;
    public bool[] endDialogueLines;
    public float autoSkipDelay = 1.5f;

    public DialogueChoice[] choices;
}

[System.Serializable]

public class DialogueChoice
{
    public int dialogueIndex;
    public string[] choices;
    public int[] nextDialogueIndexes;
}