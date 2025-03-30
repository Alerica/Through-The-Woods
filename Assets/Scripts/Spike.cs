using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
        }

        if(collision.CompareTag("Wolf"))
        {
            WolfController wolf = collision.GetComponent<WolfController>();
            if (wolf != null)
            {
                // Make sure to die
            }
        }
    }
}
