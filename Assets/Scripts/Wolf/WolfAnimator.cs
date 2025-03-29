using UnityEngine;

public class WolfAnimator : MonoBehaviour
{
    [Header("Referencess")]
    [SerializeField] WolfController wolfController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();   
    }

    private void Update() 
    {
        spriteRenderer.flipX = wolfController.IsFacingLeft;
        animator.SetBool(StringManager.isMoving, !wolfController.IsMoving);
    }
}
