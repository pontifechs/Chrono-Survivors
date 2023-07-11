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
    
    public static Rect ScreenBounds_World()
    {
        var min = ScreenMin_World();
        var max = ScreenMax_World();
        return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
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

}
