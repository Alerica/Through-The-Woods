using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField ] private PlayerAnimator playerAnimator;
    private Rigidbody2D rb2d;
    private TouchingDirections touchingDirections;
   

    private Vector2 checkPoint;

    [Header("Attributes")]
    [SerializeField] private float baseMovementSpeed = 2f;
    [SerializeField] private float sprintMultiplier = 1.5f;
    [SerializeField] private float jumpForce = 5f;


    public bool IsMoving { get; set;}
    public bool IsSprinting { get; set;}
    public bool IsFacingRight { get; set; }
    public bool IsAlive { get; set; }

    Vector2 movementInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void Start()
    {
        // I`m Setting Default to Facing Right
        IsFacingRight = true;   
        IsAlive = true;
        checkPoint = transform.position;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Movement Logic
        if(IsAlive) 
        {
            float movementSpeed = baseMovementSpeed;
            if(IsSprinting) movementSpeed *= sprintMultiplier;
            rb2d.linearVelocity = new(movementInput.x * movementSpeed, rb2d.linearVelocity.y);
        }
        
        CheckDirection();
    }

    private void CheckDirection()
    {
        if(IsFacingRight && movementInput.x < 0) IsFacingRight = !IsFacingRight;
        else if (!IsFacingRight && movementInput.x > 0) IsFacingRight = !IsFacingRight;    
        // Debug.Log(IsFacingRight);
    }

    public void Die() 
    {
        StartCoroutine (Respawn());
    }

    private IEnumerator Respawn()
    {
        IsAlive = false;
        playerAnimator.OnDie();
        rb2d.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(1.5f);
        transform.position = checkPoint;
        IsAlive = true;
    }

    public void UpdateCheckPoint(Vector2 newPosition)
    {   
        checkPoint = newPosition;
        Debug.Log($"CheckPoint updated {checkPoint}");
    }

    public void DisableMovement()
    {
        rb2d.linearVelocity = new Vector2(0, rb2d.linearVelocity.y);
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        // Debug.Log(movementInput.x);

        IsMoving =  movementInput != Vector2.zero;
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        IsSprinting = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded)
        {
            rb2d.linearVelocity += new Vector2(rb2d.linearVelocity.x, jumpForce);
        }
        
    }
}
