using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(DashDelay());
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        DashInput();
    }

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
        rb.MovePosition(transform.position + (movement * speed * Time.fixedDeltaTime));
        if (!hasDashed)
        {
            rb.MovePosition(transform.position + newPos * speed);
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