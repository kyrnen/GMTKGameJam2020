using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    new Rigidbody rigidbody;
    [SerializeField]
    float speed = 1f, destroyDelay = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        Destroy(gameObject, destroyDelay);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {

    }
}
