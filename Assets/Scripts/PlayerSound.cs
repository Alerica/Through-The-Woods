using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip[] footstepSounds;
    public float stepDelay = 0.5f;

    private float stepTimer = 0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2d.linearVelocity.magnitude > 0.1f) // Player is moving
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDelay)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; 
        }
    }

    void PlayFootstep()
    {
        int randomIndex = Random.Range(0, footstepSounds.Length);
        footstepSource.PlayOneShot(footstepSounds[randomIndex]); 
    }
}
