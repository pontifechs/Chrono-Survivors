using UnityEngine;

namespace Tunings
{
    [CreateAssetMenu(menuName="Enemy")]
    public class Enemy : ScriptableObject, HasHealth, HasSpeed
    {
        public float speed;
        public float maxHealth;

        public float MaxHealth()
        {
            return maxHealth;
        }
        
        public float Speed()
        {
            return speed;
        }
    }
}