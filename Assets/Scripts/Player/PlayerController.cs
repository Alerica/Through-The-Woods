using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;

    [Header("Attributes")]
    [SerializeField] private float baseMovementSpeed = 2f;
    [SerializeField] private float sprintMultiplier = 1.5f;


    public bool IsMoving { get; set;}
    public bool IsSprinting { get; set;}
    public bool IsFacingRight { get; set; }

    Vector2 movementInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // I`m Setting Default to Facing Right
        IsFacingRight = true;   
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Movement Logic
        float movementSpeed = baseMovementSpeed;
        if(IsSprinting) movementSpeed *= sprintMultiplier;
        rb2d.linearVelocity = new(movementInput.x * movementSpeed, 0);


        CheckDirection();
    }

    private void CheckDirection()
    {
        if(IsFacingRight && movementInput.x < 0) IsFacingRight = !IsFacingRight;
        else if (!IsFacingRight && movementInput.x > 0) IsFacingRight = !IsFacingRight;    
        // Debug.Log(IsFacingRight);
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
}
