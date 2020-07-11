using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    Transform objectHolder;
    //the sibling index of the selected item
    int selectedObj = 0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => SelectObject();

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other) => PickUpInput(other.gameObject);

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ResetHolder();
    }

    //input for picking up items
    void PickUpInput(GameObject other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpID pickUpID = other.gameObject.GetComponent<PickUpID>();
            if (pickUpID != null)
            {
                selectedObj = pickUpID.id;
                SelectObject();
                Destroy(other.gameObject);
            }
        }
    }

    //checks the sibling index of each child of object holder.
    //if the sibling index of the child is equal to selected object, if not, we set it active to false
    void SelectObject()
    {
        int i = 0;
        foreach (Transform obj in objectHolder)
        {
            if (i == selectedObj)
            {
                obj.gameObject.SetActive(true);
            }
            else
                obj.gameObject.SetActive(false);
            i++;
        }
    }

    //resets the item holder
    public void ResetHolder()
    {
        selectedObj = 0;
        SelectObject();
    }

    //returns the selected object
    public int GetObjID()
    {
        return selectedObj;
    }
}
