using UnityEngine;

public class DeadZone : MonoBehaviour
{
    PlayerController playerController;

    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Red Hood").GetComponent<PlayerController>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood"))
        {
            playerController.Die();
        }
    }
}
