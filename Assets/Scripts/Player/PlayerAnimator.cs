using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Referencess")]
    [SerializeField] PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();   
    }

    private void Update() 
    {
        spriteRenderer.flipX = !playerController.IsFacingRight;
        animator.SetBool(StringManager.isMoving, playerController.IsMoving);
    }

    public void OnDie()
    {
        animator.SetTrigger(StringManager.isDie);
    }
}
