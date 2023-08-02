using Health;
using UnityEngine;

namespace Weapons
{
    public class Collision : MonoBehaviour
    {
        // TODO:: Rename? -- or do something smarter?
        [SerializeField] int dmgIcd;
        [SerializeField] int dmg;

        private Health.Health target;
        private int remainingIcd = 0;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            target = collision.gameObject.GetComponent<Health.Health>();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            target = null;
        }

   
        private void FixedUpdate()
        {
            if (target != null)
            {

                if (remainingIcd <= 0)
                {
                    target.TakeDamage(dmg);
                    remainingIcd = dmgIcd;
                } 
                else
                {
                    remainingIcd -= 1;
                }
            }
        }

    }
}
