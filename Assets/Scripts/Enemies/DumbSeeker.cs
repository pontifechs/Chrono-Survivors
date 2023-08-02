using Tunings;
using UnityEngine;

namespace Enemies
{
    public class DumbSeeker : MonoBehaviour
    {
        private HasSpeed tuning;
        
        Rigidbody2D rb;

        Transform target;
        Vector2 move;  

        void Awake()
        {
            tuning = GetComponent<TuningReference>().Get<HasSpeed>(); 
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.Find("Player").transform;
        }

        void Update()
        {
            if (target != null)
            {
                move = (target.position - transform.position).normalized;
            }
        }

        void FixedUpdate()
        {
            if (target != null)
            {
                rb.velocity = move * tuning.Speed();
            }
        }
    }
}
