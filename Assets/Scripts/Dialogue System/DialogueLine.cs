using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(3, 5)] public string dialogueText;
    public Sprite characterPortrait;
    public bool hasChoices;
    public List<DialogueChoice> choices;
}

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;
    public int nextDialogueIndex;  // -1 for end
}
