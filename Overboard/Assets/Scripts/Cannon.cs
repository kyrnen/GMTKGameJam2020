using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    Transform player;
    public float delay;
    public GameObject bullet;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        StartCoroutine(Shoot());
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        transform.LookAt(player);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delay);
        Instantiate(bullet);
        bullet.transform.position = transform.position + transform.forward * .5f;
        bullet.transform.LookAt(player);
        StartCoroutine(Shoot());
    }
}
