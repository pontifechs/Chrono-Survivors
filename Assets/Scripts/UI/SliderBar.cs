using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    // TODO:: Maybe delete this... Noodle
    public class SliderBar : MonoBehaviour
    {
        [SerializeField] Slider slider;

        public void SetHealth(float healthPercent)
        {
            slider.value = healthPercent; 
        }
    }
}
