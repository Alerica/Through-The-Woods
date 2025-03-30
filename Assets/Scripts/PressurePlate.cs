using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] objectToBeActivated;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood") || collision.CompareTag("Wolf")) 
        foreach (GameObject _object in objectToBeActivated) 
        {
            _object.SetActive(true);
        }
       
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Red Hood") || collision.CompareTag("Wolf")) 
        foreach (GameObject _object in objectToBeActivated) 
        {
            _object.SetActive(false);
        }
    }
}
