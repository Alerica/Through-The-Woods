using UnityEngine;

public class Key : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.FirstKey = true;
        Destroy(gameObject);;
    }
}
