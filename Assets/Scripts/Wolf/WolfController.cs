using UnityEngine;
using UnityEngine.InputSystem;

public class WolfController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;

    [Header("Attributes")]
    [SerializeField] private float baseMovementSpeed = 2f;
    [SerializeField] private float sprintMultiplier = 1.5f;


    public bool IsMoving { get; set;}
    public bool IsSprinting { get; set;}
    public bool IsFacingLeft { get; set; }

    Vector2 movementInput = Vector2.zero;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // I`m Setting Default to Facing Right
        IsMoving = false;
        IsFacingLeft = false;   
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
        if(IsFacingLeft && movementInput.x < 0) IsFacingLeft = !IsFacingLeft;
        else if (!IsFacingLeft && movementInput.x > 0) IsFacingLeft = !IsFacingLeft;    
        // Debug.Log(IsFacingLeft);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log(movementInput.x);

        IsMoving =  movementInput != Vector2.zero;
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        IsSprinting = context.ReadValueAsButton();
    }
}
