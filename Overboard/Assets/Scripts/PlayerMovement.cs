﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    public float speed, dashSpeed, dashDelay;
    public int PlayerNumber = 1;
    Vector3 moveDir, lastPos, newPos;
    bool hasDashed = true, canDash;
    [SerializeField]
    string horizontal = "Horizontal", vertical = "Vertical";

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => StartCoroutine(DashDelay());

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MoveInput();
        DashInput();
    }

    void MoveInput() => Debug.Log("ef");

    void DashInput()
    {
        if (Input.GetKeyDown(Keys.GetKey((PlayerNumber-1)*3)) && canDash)
        {
            hasDashed = false;
            canDash = false;
            StartCoroutine(DashDelay());
        }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() => Move();

    void Move()
    {
        newPos = transform.position - lastPos;
        Vector3 movement = new Vector3(Input.GetAxisRaw(horizontal), 0f, Input.GetAxisRaw(vertical)).normalized;
        rigidbody.MovePosition(transform.position + (movement * speed * Time.fixedDeltaTime));
        if (!hasDashed)
        {
            rigidbody.MovePosition(transform.position + newPos * speed);
            hasDashed = true;
        }
        lastPos = transform.position;
    }

    IEnumerator DashDelay()
    {
        yield return new WaitForSeconds(dashDelay);
        canDash = true;
    }
}