using System.Collections;
using UnityEditor.U2D.Aseprite;
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

        // TODO:: Move somewhere else.
        var hasHealth = GetComponent<HasHealth>(); 
        if (hasHealth)
        {
            hasHealth.OnDeath += StartFadeout;
        }
    }

    void StartFadeout()
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
