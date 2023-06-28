using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    [SerializeField] public float dmg;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hit");
        collider.GetComponent<HasHealth>().TakeDamage(dmg);
    }
}
