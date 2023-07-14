using System.Collections.Generic;
using UnityEngine;


static class Utils
{
    public static Vector2 ScreenMin_World()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public static Vector2 ScreenMax_World()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    
    public static (Vector2 min, Vector2 max) ScreenBounds_World()
    {
        return (ScreenMin_World(), ScreenMax_World());
    }

    public static bool flipCoin()
    {
        return Random.Range(0, 1) == 0;
    }

    public static T RandomElement<T>(this List<T> collection)
    {
        if (collection.Count == 0)
        {
            return default(T);
        }
        return collection[Random.Range(0, collection.Count)];
    }

    public static Vector2 xy(this Vector3 source)
    {
        return new Vector2(source.x, source.y);
    }

}
