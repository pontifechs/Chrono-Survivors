using Tunings;
using UnityEngine;

namespace Items
{
    public class Gem : MonoBehaviour
    {
        [SerializeField] private ItemZoom itemZoom;
        
        public int points = 1;
        
        private Transform zoomTo;
        private float velocity;


        private void OnTriggerEnter2D(Collider2D collider)
        {
            GetComponent<Collider2D>().enabled = false;
            // Check on parent, player has a separate object for the xp collider.
            var experience = collider.GetComponentInParent<Experience>();
            if (experience)
            {
                experience.CollectExperience(points);
            }

            zoomTo = collider.transform;
        }

        private void FixedUpdate()
        {
            if (!zoomTo) return;

            var offset = (zoomTo.position - transform.position);
            if (offset.magnitude <= itemZoom.deadzone)
            {
                Destroy(gameObject);
            }

            transform.position += offset.normalized * velocity;
            velocity += itemZoom.acceleration;
        }
    }
}