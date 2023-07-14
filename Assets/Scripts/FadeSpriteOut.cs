using System.Collections;
using UnityEngine;

public class FadeSpriteOut : MonoBehaviour
{
    [SerializeField] bool onStart;
    [SerializeField] float duration;

    private void Awake()
    {
        if (onStart)
        {
            StartFadeout();
        }

        // TODO:: Move somewhere else. (T + 6-8 days) ya..... this reeks.
        var hasHealth = GetComponent<HasHealth>(); 
        if (hasHealth)
        {
            hasHealth.OnDeath += StartFadeout;
        }
    }

    public void StartFadeout()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut(spriteRenderer));
    }

    IEnumerator FadeOut(SpriteRenderer spriteRenderer)
    {
        Color c = spriteRenderer.color;
        while (c.a > 0f)
        {
            c.a -= Time.deltaTime / duration;
            spriteRenderer.color = c;
            yield return null;    
        }

        spriteRenderer.color = c;

        Destroy(gameObject);
    }

}
