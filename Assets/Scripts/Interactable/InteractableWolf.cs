using UnityEngine;

public class InteractableWolf : MonoBehaviour, InteractableInterface
{
    [Header("References")]
    [SerializeField] private GameObject wolf;
    private DialogueTriggerManual dialogueTriggerManual;

    private void Awake()
    {
        dialogueTriggerManual = GetComponent<DialogueTriggerManual>();   
    }
    public bool canInteract()
    {
        Debug.Log("Can Interact");
        return true;
    }

    public void Interact()
    {
        Debug.Log("Interacting");
        wolf.transform.position = transform.position;
        CharacterSwitchManager.Instance.ActivateWolf();
        Destroy(gameObject, 0.1f);
        dialogueTriggerManual.StartDialogue();
    }

}
