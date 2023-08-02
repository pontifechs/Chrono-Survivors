using UnityEngine;

namespace Tunings
{
    [CreateAssetMenu(menuName = "ItemZoom")]
    public class ItemZoom : ScriptableObject
    {
        [SerializeField] public float acceleration = 0.1f;
        [SerializeField] public float deadzone = 0.5f;
    }
}