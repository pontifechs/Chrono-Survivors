using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : Repeating
{
    [SerializeField] GameObject blobPrefab;
    protected override void Repeat()
    {
        SpawnBlob();
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

        Instantiate(blobPrefab, position, Quaternion.identity);
    }

    public void OnToggleSpawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("toggling: " + enabled);
            enabled = !enabled;
        }
    }
}