using UnityEngine;

namespace Tunings
{
    [CreateAssetMenu(menuName="PlayerTuning")]
    public class PlayerTuning : ScriptableObject, HasHealth, HasSpeed
    {
        public float health;
        public float speed;
        
        public float MaxHealth()
        {
            return health;
        }

        public float Speed()
        {
            return speed;
        }
    }
}