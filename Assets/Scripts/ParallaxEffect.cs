using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform followTargerRedHood;

    Vector2 startingPosition;
    Vector2 camMoveSinceStart => (Vector2) cam.transform.position - startingPosition;
    float zDistanceFromTarget => transform.position.z - followTargerRedHood.transform.position.z;
    float clippingPlane => cam.transform.position.z + (zDistanceFromTarget > 0? cam.farClipPlane : cam.nearClipPlane);
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    float startingZ;

    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;   
    }

    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
