using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject blobPrefab;

    void Start()
    {
        // TODO:: make this smarter
        InvokeRepeating("SpawnBlob", 0, 1f);
    }


    void SpawnBlob()
    {
        var origin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        var max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector2 position;

        if (Utils.flipCoin())
        {
            // Top of screen
            position = new Vector2(Random.Range(origin.x, max.x), max.y + 10);   
        } 
        else
        {
            // Bottom of screen
            position = new Vector2(Random.Range(origin.x, max.x), origin.y - 10);   
        }

        var obj = GameObject.Instantiate(blobPrefab, position, Quaternion.identity);

         
    }

}
