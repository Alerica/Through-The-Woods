using UnityEngine;

public class Campfire : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private Transform respawnPositition;
    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Red Hood").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood"))
        {
            playerController.UpdateCheckPoint(respawnPositition.position);
        }
    }
}
