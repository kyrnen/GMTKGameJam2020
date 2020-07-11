using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    //By default these will be routed to Horizontal and Vertical.
    //In the event that there are two players, a button should trigger a function that changes axes appropriately.
    //For now these will be adjustable in Inspector
    /// </summary>
    [SerializeField]
    private string horizontal = "Horizontal",
                     vertical = "Vertical";
    //speed cannot be manipulated by other functions this way but can be modified in Inspector for debugging purposes
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    private float dashSpeed = 25;
    //decrease dash time in game over time
    [SerializeField]
    private float startDashTime = 0.1f;
    //How long dash lasts
    private float dashTime;
    private int direction = 0;

    //using rigidbody poses issues sometimes
    private Rigidbody rb;
    private KeyCode dash = KeyCode.Space;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }


    private void Update()
    {
        CheckDash();
    }

    void CheckDash()
    {
        if (direction == 0 && Input.GetKeyDown(dash))
        {
            if (Input.GetAxis(horizontal) < 0)
            {
                direction = 1;
            }
            else if (Input.GetAxis(horizontal) > 0)
            {
                direction = 2;
            }
            else if (Input.GetAxis(vertical) > 0)
            {
                direction = 3;
            }
            else if (Input.GetAxis(vertical) < 0)
            {
                direction = 4;
            }
            Debug.Log(Input.GetAxis(horizontal) + ", 0, " + Input.GetAxis(vertical));
            Debug.Log("Dash direction: " + direction.ToString());
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector3.left * dashSpeed;
                }
                if (direction == 2)
                {
                    rb.velocity = Vector3.right * dashSpeed;
                }
                if (direction == 3)
                {
                    rb.velocity = new Vector3(0, 0, 1) * dashSpeed;
                }
                if (direction == 4)
                {
                    rb.velocity = new Vector3(0, 0, -1) * dashSpeed;
                }
            }
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        Debug.Log(movement.ToString());
        rb.MovePosition(transform.position + (movement * speed * Time.fixedDeltaTime));
    }
}
