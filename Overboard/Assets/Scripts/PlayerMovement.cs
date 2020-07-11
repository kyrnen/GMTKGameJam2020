using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    [SerializeField]
    float speed, dashSpeed;
    Vector3 moveDir;
    [SerializeField]
    string horizontal, vertical;
    public KeyCode dash;
    bool isDashing;
    Vector3 oldPos;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MoveInput();
    }

    void MoveInput() => moveDir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis(horizontal), 0f, Input.GetAxis(vertical)), 1f);

    void DashInput()
    {
        if (Input.GetKeyDown(dash))
            isDashing = true;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 newPos = transform.position - oldPos;
        Move(newPos);
        oldPos = transform.position;
    }

    void Move(Vector3 dashDir)
    {
        rigidbody.MovePosition(transform.position + (moveDir * speed * Time.fixedDeltaTime));

        if (isDashing)
        {
            rigidbody.MovePosition(transform.position + dashDir);
            isDashing = false;
        }
    }
}
