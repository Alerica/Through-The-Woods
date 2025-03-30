using UnityEngine;
using UnityEngine.Events;
public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogue;
    public UnityEvent onDialogueEnd;
    public void StartDialogue()
    {
        Debug.Log("Triggering Dialogue");
        DialogueManager.Instance.StartDialogue(dialogue, onDialogueEnd);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood"))
        StartDialogue();
    }
}

