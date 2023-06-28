using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] GameObject lightningPrefab;

    void Start()
    {
        InvokeRepeating("SpawnLightning", 2, 1);
    }


    void SpawnLightning()
    {
        var lightning = GameObject.Instantiate(lightningPrefab);
    } 

}
