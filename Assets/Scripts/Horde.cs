using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    // is this a good idea? my code cleanliness brain has no issue with it, but it seems like it could have performance issues?
    private static List<GameObject> visibleEnemies = new List<GameObject>();


    private void OnBecameVisible()
    {
        visibleEnemies.Add(gameObject);
    }

    private void OnBecameInvisible()
    {
        visibleEnemies.Remove(gameObject);
    }

    public static GameObject RandomVisibleEnemy()
    {
        if (visibleEnemies.Count == 0)
        {
            return null;
        }
        return visibleEnemies[Random.Range(0, visibleEnemies.Count)];
    } 

    public static GameObject ClosestEnemy(Vector3 position)
    {
        GameObject min = null;
        float minDist = Mathf.Infinity;
        

        foreach (GameObject obj in visibleEnemies)
        {
            float dist = Vector3.Distance(position, obj.transform.position);
            if (dist < minDist)
            {
                min = obj;
                minDist = dist;
            }
        }

        return min;
    }
}
