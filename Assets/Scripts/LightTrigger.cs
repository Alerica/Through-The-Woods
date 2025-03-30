using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class LightTrigger : MonoBehaviour
{
    public Light2D globalLight; 
    public float targetIntensity = 0f;
    public Color targetColor = Color.red;
    public float transitionDuration = 1.5f; 

    private float originalIntensity;
    private Color originalColor;
    private Coroutine transitionCoroutine;

    private void Start()
    {
        if (globalLight != null)
        {
            originalIntensity = globalLight.intensity;
            originalColor = globalLight.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red Hood") && globalLight != null)
        {
            StartTransition(targetIntensity, targetColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Red Hood") && globalLight != null)
        {
            StartTransition(0, originalColor);
        }
    }

    private void StartTransition(float newIntensity, Color newColor)
    {
        if (transitionCoroutine != null)
            StopCoroutine(transitionCoroutine);
        
        transitionCoroutine = StartCoroutine(TransitionLight(newIntensity, newColor));
    }

    private IEnumerator TransitionLight(float newIntensity, Color newColor)
    {
        float elapsedTime = 0f;
        float startIntensity = globalLight.intensity;
        Color startColor = globalLight.color;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            globalLight.intensity = Mathf.Lerp(startIntensity, newIntensity, t);
            globalLight.color = Color.Lerp(startColor, newColor, t);

            yield return null;
        }

        globalLight.intensity = newIntensity;
        globalLight.color = newColor;
    }
}
