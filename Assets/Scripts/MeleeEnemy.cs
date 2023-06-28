using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    // TODO:: Rename?
    [SerializeField] int dmgIcd;
    [SerializeField] float dmg;

    private HasHealth target;
    private int remainingIcd = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        target = collision.gameObject.GetComponent<HasHealth>();
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
