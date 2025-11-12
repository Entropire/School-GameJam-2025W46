using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveInput;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.x > moveSpeed || rb.linearVelocity.x < -moveSpeed) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, 0f);

    }


    public void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }
}
