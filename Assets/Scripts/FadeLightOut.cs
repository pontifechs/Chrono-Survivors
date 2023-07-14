

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

// TODO:: Is there enough common with FadeSpriteOut to bother?
public class FadeLightOut : MonoBehaviour
{
    [SerializeField] private float duration;

    private void Awake()
    {
        StartFadeout();
    }

    public void StartFadeout()
    {
        var light = GetComponent<Light2D>();
        StartCoroutine(FadeOut(light));
    }

    IEnumerator FadeOut(Light2D light)
    {
        float intensity = light.intensity;
        while (light.intensity > 0f)
        {
            light.intensity -= (Time.deltaTime / duration) * intensity;
            yield return null;
        }

        light.intensity = 0;
        
        // TODO:: Destroy? The sprite fade does... not sure if that's good.
    }
}