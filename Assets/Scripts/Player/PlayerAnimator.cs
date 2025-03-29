using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Referencess")]
    [SerializeField] PlayerController playerController;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    private void Update() 
    {
        animator.SetBool(StringManager.isMoving, playerController.IsMoving);
    }
}
