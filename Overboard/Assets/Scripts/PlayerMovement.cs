using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    public float speed, dashSpeed, dashDelay;
    Vector3 moveDir, lastPos, newPos;
    bool hasDashed = true, canDash;
    public string horizontalInput, verticalInput, dashInput;

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

    void MoveInput() => moveDir = Vector3.ClampMagnitude(Vector3.forward * Input.GetAxis(verticalInput) + Vector3.right * Input.GetAxis(horizontalInput), 1f);

    void DashInput()
    {
        if (Input.GetButtonDown(dashInput) && canDash)
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
        rigidbody.MovePosition(transform.position + (moveDir * speed * Time.fixedDeltaTime));
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
