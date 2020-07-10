using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    Transform player;
    
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        transform.LookAt(player);
    }
}
