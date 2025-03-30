using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.05f;

    CapsuleCollider2D touchingCollider;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] leftWallHits = new RaycastHit2D[5];
    RaycastHit2D[] rightWallHits = new RaycastHit2D[5];
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isOnWall;
    public bool IsGrounded { get {
        return _isGrounded; 
    } set {
        _isGrounded = value;
    } }
    public bool IsOnWall { get {
        return _isOnWall;
    } set {
        _isOnWall = value;
    } }

    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWall = 
            touchingCollider.Cast(Vector2.left, castFilter, leftWallHits, wallDistance) > 0 || 
            touchingCollider.Cast(Vector2.right, castFilter, rightWallHits, wallDistance) > 0;
    }
}
