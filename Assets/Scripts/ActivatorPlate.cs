using UnityEngine;

public class ActivatorPlate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Itemprefabs;
    [SerializeField] Transform spawnPosition;
    private bool triggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered) 
        {
            Instantiate(Itemprefabs, spawnPosition.position, Quaternion.identity);
            triggered = true;
        }
        
    }
}
