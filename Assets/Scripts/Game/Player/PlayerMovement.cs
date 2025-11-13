using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Boundary = 3f;
    public float moveSpeed = 5f;
    private float moveInput;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -Boundary, Boundary), 
            transform.position.y);

        if (Mathf.Abs(moveInput) < 0.2f) return;

        if (rb.linearVelocity.x > moveSpeed || rb.linearVelocity.x < -moveSpeed) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, 0f);
    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }
}
