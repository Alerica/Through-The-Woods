using UnityEngine;

public class Door : MonoBehaviour, InteractableInterface
{
    Animator animator;
    DialogueTriggerManual dialogueTriggerManual;

    public bool canInteract()
    {
        return true;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();   
        dialogueTriggerManual = GetComponent<DialogueTriggerManual>();
    }

    public void Interact()
    {
        if(GameManager.Instance.FirstKey) 
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            animator.SetBool("Open", true);
            collider.enabled = false;
        }
        else 
        {
            dialogueTriggerManual.StartDialogue();
        }
    }

}
