using System;
using Tunings;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private HasSpeed tuning;

    public Action<bool> OnMoveChanged;
    public Action<Direction> OnDirectionChanged;
    
    private Rigidbody2D rigidBody;
    private Vector2 move;

    private Direction direction;
    
    public enum Direction {
        Up, Down, Left, Right
    }

    private void Awake()
    {
        tuning = GetComponent<TuningReference>().Get<HasSpeed>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!enabled) return;
        
        var lastDirection = direction;

        move = context.ReadValue<Vector2>();
        
        direction = getDirection(move);

        if (context.started)
        {
            OnMoveChanged?.Invoke(true);
            OnDirectionChanged?.Invoke(direction);
        } 
        else if (context.canceled)
        {
            OnMoveChanged?.Invoke(false);
        }
        else
        {
            if (lastDirection != direction)
            {
                OnDirectionChanged?.Invoke(direction);
            }           
        }
    }
    
    private static Direction getDirection(Vector2 move)
    {
        if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
        {
            return move.x > 0 ? Direction.Right : Direction.Left;
        }
        return move.y > 0 ? Direction.Up : Direction.Down;
    }

    public void FixedUpdate()
    {
        if (enabled)
        {
            rigidBody.velocity = move * tuning.Speed();
        }
        else
        {
            rigidBody.velocity = new Vector2();
        }
    }
}