using UnityEngine;

namespace Items
{
    public class Gem : MonoBehaviour
    {
        [SerializeField] private int points = 1;
        
        private void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("hit");
            var experience = collider.GetComponent<Experience>();
            if (experience)
            {
                experience.CollectExperience(points);
            }
            Destroy(gameObject);
        }
    }
}