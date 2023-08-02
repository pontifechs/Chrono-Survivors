using Health;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Weapons;

[RequireComponent(typeof(Health.Health))]
[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    private Health.Health health;
    private Movement movement;
    
    private void Awake()
    {
        health = GetComponent<Health.Health>();
        health.OnDeath += die;
        movement = GetComponent<Movement>();
    }

    private void die()
    {
        movement.enabled = false;
        Invoke(nameof(returnToMenu), 3);
    }

    private void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnToggleFlame(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var flame = GetComponent<FlameOrbit>();
        flame.enabled = !flame.enabled;
    }
    
    public void OnToggleKnife(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var knife = GetComponent<Knife>();
        knife.enabled = !knife.enabled;
    }
    
    public void OnToggleLightning(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        var lightning = GetComponent<Lightning>();
        lightning.enabled = !lightning.enabled;
    }
}