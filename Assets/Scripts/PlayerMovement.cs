using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveInput;

    public float activeMoveSpeed;

    
    void Start()
    {
        activeMoveSpeed = moveSpeed;

    }

    private void Update()
    { 
        Vector3 move = new Vector3(moveInput * activeMoveSpeed * Time.deltaTime, 0, 0);
        transform.position += move;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, transform.position.z);///voorkomt niet buiten scherm

    }


    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveInput = input.x;
        Debug.Log("Move Input: " + moveInput);
    }
}
