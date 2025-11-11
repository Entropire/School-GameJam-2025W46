using UnityEngine;

public class Movement : MonoBehaviour
{
    public  float moveSpeed = 5f;
    private float moveInput;

    private float activeMoveSpeed;
    public float dashSpeed = 20f;

    public float dashlenght = 0.5f; //hoe lang de dash duurt
    public float dashCooldown = 1f; //hoe lang het duurt voordat je weer kan dashen

    private float dashTime; //teller die aftelt tijdens de dash
    private float dashCooldownTime; ///teller die aftelt tijdens de cooldown

    void Start()
    {
       activeMoveSpeed = moveSpeed;
       
    }   

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3 (moveInput * activeMoveSpeed * Time.deltaTime, 0, 0) ;
        transform.position += move;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, transform.position.z);///voorkomt niet buiten scherm


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //alleen dashen als de cooldown voorbij is en je niet al aan het dashen bent
            if (dashCooldownTime <=0 && dashTime <=0)
            {
                activeMoveSpeed = dashSpeed; //verhoog de snelheid
                dashTime = dashlenght; //zet de dash timer aan

            }
        }
        if(dashTime > 0)
        {
            dashTime -= Time.deltaTime; // elke frame minder tijd

            if(dashTime <=0) //dash afgelopen..?
            {
                activeMoveSpeed = moveSpeed;// terug naar normale snelheid
                dashCooldownTime = dashCooldown; // zet de cooldown timer aan
            }
        }

        if (dashCooldownTime > 0) // Cooldown timer aftellen
        {
            dashCooldownTime -= Time.deltaTime;
        }
    }

}
