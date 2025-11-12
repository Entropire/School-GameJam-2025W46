using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(-(Screen.height + transform.localScale.y));
    }

    void FixedUpdate() 
    {
        rb.linearVelocity = Vector2.down * speed;

        if (transform.position.y < -((Camera.main.orthographicSize * 2) + transform.localScale.y))
        {
            Destroy(gameObject);
        }
    }
}
