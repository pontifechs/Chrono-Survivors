using System.Collections;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class FadeSpriteOut : MonoBehaviour
{

    [SerializeField] float duration;

    void Start()
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
    }

}
