using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    public float speed;

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 moveDir = transform.position + Vector3.ClampMagnitude(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal"), 1f) * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(moveDir);
    }
}
