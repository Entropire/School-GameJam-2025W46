using UnityEngine;
using UnityEngine.Events;

public class CarCollisionTrigger : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player2";
    [SerializeField] private UnityEvent onCollisionWithTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            onCollisionWithTarget?.Invoke();
        }
    }
}