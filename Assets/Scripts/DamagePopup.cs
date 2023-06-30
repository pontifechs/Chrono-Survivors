using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] GameObject floatingTextPrefab;

    void Start()
    {
        var hasHealth = GetComponent<HasHealth>();
        if (hasHealth)
        {
            hasHealth.OnTakeDamage += PopFloatingText;
        }
    }

    void PopFloatingText(int dmg)
    {
        var text = GameObject.Instantiate(floatingTextPrefab, transform);
        var textComponent = text.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.alpha = 1;
        textComponent.text = dmg.ToString();
        textComponent.CrossFadeAlpha(0, .5f, false);
    }

}
