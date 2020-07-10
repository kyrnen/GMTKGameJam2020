using UnityEngine;

public class MaterialPickup : MonoBehaviour
{
    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionStay(Collision other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            MaterialPickUpable materialPickUpable = other.gameObject.GetComponent<MaterialPickUpable>();
            if (materialPickUpable != null)
            {
                PlayerPrefs.SetInt(materialPickUpable.resourceType, materialPickUpable.resourceAmnt);
                Destroy(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }
}
