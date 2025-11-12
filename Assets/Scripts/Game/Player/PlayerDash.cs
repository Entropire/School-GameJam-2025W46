using System;
using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;

    public float dashlenght = 0.5f;
    public float dashCooldown = 1f;

    private float lastDash;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    public void OnAction()
    {
        if (Time.time - lastDash < dashCooldown) return;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x * dashSpeed, 0f);
        StartCoroutine(StopDash());

        lastDash = Time.time;
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashlenght);
        rb.linearVelocity = new Vector2(0f, 0f);
    }
}

