using TMPro;
using UnityEngine;

namespace Health
{
    [RequireComponent(typeof(HasHealth))]
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

        void PopFloatingText(float dmg)
        {
            var text = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            var textComponent = text.GetComponentInChildren<TextMeshProUGUI>();
            textComponent.alpha = 1;
            textComponent.text = dmg.ToString();
            textComponent.CrossFadeAlpha(0, .5f, false);
            Destroy(text, 1);
        }
    }
}
