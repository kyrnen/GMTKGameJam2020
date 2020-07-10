using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    Transform objectHolder;
    int selectedObj;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SelectObject();
    }

    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionStay(Collision other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("f");
            PickUpID pickUpID = other.gameObject.GetComponent<PickUpID>();
            if (pickUpID != null)
            {
                selectedObj = pickUpID.id;
                SelectObject();
                Debug.Log("c");
                Destroy(other.gameObject);
            }
        }
    }

    void SelectObject()
    {
        int i = 0;
        foreach (Transform weapon in objectHolder)
        {
            if (i == selectedObj)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
