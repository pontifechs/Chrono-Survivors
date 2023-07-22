using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Weapons;

// TODO:: Do more of this. Seems useful.
[RequireComponent(typeof (HasHealth))]
public class Crono : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private HasHealth hasHealth;

    private bool alive = true;
    

    enum Direction {
        Up, Down, Left, Right
    }
    Vector2 move;
    Direction direction = Direction.Down;

    private void Awake()
    {
        alive = true;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        hasHealth = GetComponent<HasHealth>();
        hasHealth.OnDeath += die;
        hasHealth.OnTakeDamage += takeDamage;
    }    

    public void OnMove(InputAction.CallbackContext context)
    {
        var lastDirection = direction;
        move = context.ReadValue<Vector2>();
        direction = getDirection(move);

        if (context.performed)
        {
            switch (direction)
            {
                case Direction.Up:
                    animator.Play("WalkUp");
                    break;
                case Direction.Down:
                    animator.Play("WalkDown");
                    break;
                case Direction.Right:
                    animator.Play("WalkRight");
                    spriteRenderer.flipX = false;
                    break;
                case Direction.Left:
                    animator.Play("WalkRight");
                    spriteRenderer.flipX = true;
                    break;
            }
        }
        else if (context.canceled)
        {
            switch (lastDirection)
            {
                case Direction.Up:
                    animator.Play("IdleUp");
                    break;
                case Direction.Down:
                    animator.Play("IdleDown");
                    break;
                case Direction.Right:
                    animator.Play("IdleRight");
                    spriteRenderer.flipX = false;
                    break;
                case Direction.Left:
                    animator.Play("IdleRight");
                    spriteRenderer.flipX = true;
                    break;
            }
        }
    }

    private static Direction getDirection(Vector2 move)
    {
        if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
        {
            return move.x > 0 ? Direction.Right : Direction.Left;
        }
        else
        {
            return move.y > 0 ? Direction.Up : Direction.Down;
        }
    }

    public void FixedUpdate()
    {
        
        // TODO:: Blink
        
        if (alive)
        {
            rigidBody.velocity = move * speed;
        }
        else
        {
            rigidBody.velocity = new Vector2();
        }
    }


    private void takeDamage(int dmg)
    {
        // TODO:: flash red? Animation?
        // Debug.Log("ow: " + dmg);
    }

    private void die()
    {
        spriteRenderer.color = new Color(1, 0, 0);
        alive = false;
        Invoke(nameof(returnToMenu), 3); 
    }

    private void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnToggleFlame(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        Debug.Log("toggle flame");
        var flame = GetComponent<FlameOrbit>();
        flame.enabled = !flame.enabled;
        // smile -- won't work.           
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