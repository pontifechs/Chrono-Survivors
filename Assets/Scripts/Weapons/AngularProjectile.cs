using UnityEngine;

namespace Weapons
{
    public class AngularProjectile : MonoBehaviour
    {
        [SerializeField] public float angle;
        [SerializeField] public float speed;

        private void FixedUpdate()
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position += transform.up * speed;
        }
    }
}
