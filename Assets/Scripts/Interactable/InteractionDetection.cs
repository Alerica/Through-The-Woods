using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetection : MonoBehaviour
{
    private InteractableInterface interactableInRange = null;
    public GameObject interactionIcon;

    private void Start()
    {
        interactionIcon.SetActive(false);   
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log($"Interacting with {interactableInRange}");
        interactableInRange?.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out InteractableInterface interactable) && interactable.canInteract())
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out InteractableInterface interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }
    }

}
