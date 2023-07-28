using Health;
using UnityEngine;

namespace Weapons
{
    public class DamageOnCollision : MonoBehaviour
    {
        [SerializeField] public int dmg;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var hasHealth = collider.GetComponent<HasHealth>();
            if (hasHealth)
            {
                hasHealth.TakeDamage(dmg);   
            }
        }
    }
}