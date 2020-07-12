using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeySetter : MonoBehaviour
{
    [SerializeField]
    int keyIndex;
    [SerializeField]
    Text text;
    [SerializeField]
    new string name;
    public bool mouseIsOver;

    public void SetMouseIsOver(bool isTrue)
    {
        mouseIsOver = isTrue;
    }

    void OnGUI()
    {
        Event e = Event.current;

        if (mouseIsOver)
            if (e.isKey)
            {
                if (e.keyCode != KeyCode.None)
                {
                    Keys.SetKey(e.keyCode, keyIndex);
                }
            }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Input.mousePosition, Vector3.forward);
    }

    private void Update()
    {
        text.text = name + Keys.GetKey(keyIndex);
    }
}
