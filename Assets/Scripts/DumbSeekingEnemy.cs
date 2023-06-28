using UnityEngine;

public class DumbSeekingEnemy : MonoBehaviour
{
    [SerializeField] float speed = 1;

    Rigidbody2D rb;

    Transform target;
    Vector2 move;  

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // TODO:: how to get this smarter
        target = GameObject.Find("crono").transform;
    }

    void Update()
    {
        if (target != null)
        {
            move = (target.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            rb.velocity = move * speed;
        }
    }
}
