using UnityEngine;

namespace Weapons
{
    public class AngularProjectile : MonoBehaviour
    {
        [SerializeField] public float angle;
        [SerializeField] public float speed;

        private void FixedUpdate()
        {
            Transform transform1; // man this thing Rider made is ugly. But it's not complaining anymore... I think i get it, but seems overkill? Shouldn't the jvm-equivalent know better?
            (transform1 = transform).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform1.position += transform1.up * speed;
        }
    }
}
