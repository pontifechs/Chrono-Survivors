using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (HasHealth))]
public class Crono : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private HasHealth hasHealth;

    enum Direction {
        Up, Down, Left, Right
    }
    Vector2 move;
    Direction direction = Direction.Down;

    private void Awake()
    {
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
        rigidBody.velocity = move * speed;
    }


    private void takeDamage(float dmg)
    {
        // TODO:: flash red? Animation?
        Debug.Log("ow: " + dmg);
    }

    private void die()
    {
        // TODO:: disable movement.
        spriteRenderer.color = new Color(1, 0, 0);
    }

}
