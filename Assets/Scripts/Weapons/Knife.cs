using UnityEngine;

namespace Weapons
{
    public class Knife : Repeating
    {
        [SerializeField] private int dmg = 1;
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private GameObject knifePrefab;
    
        void ThrowKnife()
        {
            var target = Horde.ClosestEnemy(gameObject.transform.position);
            if (!target)
            {
                return;
            }

            var knife = Instantiate(knifePrefab, transform.position, Quaternion.identity);
            var projectile = knife.GetComponent<AngularProjectile>();
            projectile.speed = speed;
            projectile.angle = Vector3.SignedAngle(target.transform.position - gameObject.transform.position, Vector3.up, Vector3.back);
            Debug.Log(projectile.angle);
            
            knife.GetComponent<DamageOnCollision>().dmg = dmg;
        
            // TODO:: Think more about this. it's probably fine but...    
            Destroy(knife, 2.0f);
        }

        protected override void Repeat()
        {
            ThrowKnife();
        }
    }
}