using UnityEngine;

class Utils
{
    public static Vector2 ScreenMin_World()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public static Vector2 ScreenMax_World()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public static bool flipCoin()
    {
        return Random.Range(0, 1) == 0;
    }
}
