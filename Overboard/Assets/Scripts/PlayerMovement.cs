using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    public float speed;
    Vector3 moveDir;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() => MoveInput();

    void MoveInput() => moveDir = Vector3.ClampMagnitude(Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal"), 1f);

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() => Move();

    void Move() => rigidbody.MovePosition(transform.position + (moveDir * speed * Time.fixedDeltaTime));
}
