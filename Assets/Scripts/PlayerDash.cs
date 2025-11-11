using System;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;

    public float dashlenght = 0.5f; //hoe lang de dash duurt
    public float dashCooldown = 1f; //hoe lang het duurt voordat je weer kan dashen

    private float dashTime; //teller die aftelt tijdens de dash
    private float dashCooldownTime; ///teller die aftelt tijdens de cooldown


    private PlayerMovement movement; //referentie naar de PlayerMovement script
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();

    }

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //alleen dashen als de cooldown voorbij is en je niet al aan het dashen bent
            if (dashCooldownTime <= 0 && dashTime <= 0)
            {
                movement.activeMoveSpeed = dashSpeed; //verhoog de snelheid
                dashTime = dashlenght; //zet de dash timer aan

            }
        }
        if (dashTime > 0)
        {
            dashTime -= Time.deltaTime; // elke frame minder tijd

            if (dashTime <= 0) //dash afgelopen..?
            {
                movement.activeMoveSpeed = movement.moveSpeed;// terug naar normale snelheid
                dashCooldownTime = dashCooldown; // zet de cooldown timer aan
            }
        }

        if (dashCooldownTime > 0) // Cooldown timer aftellen
        {
            dashCooldownTime -= Time.deltaTime;
        }
    }
      
    }

