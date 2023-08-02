using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class FlameOrbit : MonoBehaviour
    {
        [SerializeField] private GameObject orbiterPrefab;
        
        [SerializeField] private int numOrbiters = 3;
        [SerializeField] private float orbitRadius = 2.0f;
        [SerializeField] private float orbitSpeed = 5.0f;
        [SerializeField] private int dmg = 3;
        [SerializeField] private float duration;
        [SerializeField] private float cooldown;
        
        private readonly List<GameObject> orbiters = new();

        private void Start()
        {
            SpawnOrbit();
        }

        // Is there a nicer way to do this? 2m of googling left me with nothing.
        private void OnEnable()
        {
            //TODO:: Fade in/out
            orbiters.ForEach((orbiter) => {orbiter.SetActive(true);});
        } 
        
        private void OnDisable()
        {
            orbiters.ForEach((orbiter) => { orbiter.SetActive(false);});
        }
        
        private void SpawnOrbit()
        {
            for (int i = 0; i < numOrbiters; i++)
            {
                var angle = i * (360 / numOrbiters);
                var offset = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * orbitRadius;

                var orbiter = Instantiate(orbiterPrefab, transform);
                orbiter.transform.localPosition = offset;
                orbiter.transform.parent = transform;
                orbiter.GetComponent<DamageOnCollision>().dmg = dmg;
                orbiters.Add(orbiter); 
            }
        }

        private void FixedUpdate()
        {
            foreach (var orbiter in orbiters)
            {
                orbiter.transform.localPosition = Quaternion.AngleAxis(orbitSpeed, Vector3.back) * orbiter.transform.localPosition;
            }
        }

        private void OnDestroy()
        {
            orbiters.ForEach(Destroy);
        }
    }
}
