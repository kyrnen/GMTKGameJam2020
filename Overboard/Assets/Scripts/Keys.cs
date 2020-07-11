using UnityEngine;

public static class Keys
{
    public static KeyCode[] keys = new KeyCode[6];

    public static void SetKey(KeyCode keyCode, int index)
    {
        keys[index] = keyCode;
    }

    public static KeyCode GetKey(int ID)
    {
        return keys[ID];
    }
}
