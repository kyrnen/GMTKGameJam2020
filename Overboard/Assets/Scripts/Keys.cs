using UnityEngine;

public static class Keys
{
    public static KeyCode[] keys = new KeyCode[] { KeyCode.Space, KeyCode.E, KeyCode.F, KeyCode.P, KeyCode.O, KeyCode.Alpha0 };

    public static void SetKey(KeyCode keyCode, int index)
    {
        keys[index] = keyCode;
    }

    public static KeyCode GetKey(int ID)
    {
        return keys[ID];
    }
}
