using UnityEngine;

public abstract class Repeating : MonoBehaviour
{
    [SerializeField] private float frequency = 1;

    protected abstract void Repeat();

    protected void OnEnable()
    {
        InvokeRepeating(nameof(Repeat), 0, frequency);
    }

    protected void OnDisable()
    {
        CancelInvoke(nameof(Repeat)); 
    }
}