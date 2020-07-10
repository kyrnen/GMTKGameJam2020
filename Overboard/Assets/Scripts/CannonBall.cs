using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    [SerializeField]
    float speed = 1f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => rigidbody.velocity = transform.forward * speed;
}
