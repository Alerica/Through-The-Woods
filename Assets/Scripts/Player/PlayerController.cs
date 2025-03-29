using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;

    [Header("Attributes")]
    [SerializeField] private float movementSpeed = 2f;


    public bool IsMoving { get; set;}

    Vector2 movementInput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb2d.linearVelocity = new(movementInput.x * movementSpeed, movementInput.y);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        // Debug.Log(movementInput.x);

        IsMoving =  movementInput != Vector2.zero;
    }
}
