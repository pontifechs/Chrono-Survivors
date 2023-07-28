using UnityEngine;


namespace Sprites
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Movement))]
    public class Crono : MonoBehaviour
    {
        private Animator animator;
        private SpriteRenderer spriteRenderer;

        private bool moving;
        private Movement.Direction direction = Movement.Direction.Down;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            var movement = GetComponent<Movement>();
            movement.OnDirectionChanged += directionChanged;
            movement.OnMoveChanged += movingChanged;
        }

        private void directionChanged(Movement.Direction newDirection)
        {
            direction = newDirection;
            playCorrectAnimation();
        }

        private void movingChanged(bool newMoving)
        {
            moving = newMoving;
            playCorrectAnimation();
        }
        
        private void playCorrectAnimation()
        {
            if (moving)
            {
                switch (direction)
                {
                    case Movement.Direction.Up:
                        animator.Play("WalkUp");
                        break;
                    case Movement.Direction.Down:
                        animator.Play("WalkDown");
                        break;
                    case Movement.Direction.Right:
                        animator.Play("WalkRight");
                        spriteRenderer.flipX = false;
                        break;
                    case Movement.Direction.Left:
                        animator.Play("WalkRight");
                        spriteRenderer.flipX = true;
                        break;
                }
            }
            else 
            {
                switch (direction)
                {
                    case Movement.Direction.Up:
                        animator.Play("IdleUp");
                        break;
                    case Movement.Direction.Down:
                        animator.Play("IdleDown");
                        break;
                    case Movement.Direction.Right:
                        animator.Play("IdleRight");
                        spriteRenderer.flipX = false;
                        break;
                    case Movement.Direction.Left:
                        animator.Play("IdleRight");
                        spriteRenderer.flipX = true;
                        break;
                }
            }
        }
    }
}