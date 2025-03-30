using UnityEngine;
using UnityEngine.Events;
public class DialogueTriggerManual : MonoBehaviour
{
    public DialogueData dialogue;
    public UnityEvent onDialogueEnd;
    public void StartDialogue()
    {
        Debug.Log("Triggering Dialogue");
        DialogueManager.Instance.StartDialogue(dialogue, onDialogueEnd);
    }
}

