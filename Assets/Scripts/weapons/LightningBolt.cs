using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    [SerializeField] public int dmg;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.GetComponent<HasHealth>().TakeDamage(dmg);
    }
}
