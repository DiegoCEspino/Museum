using UnityEngine;

public class HUDController : MonoBehaviour
{

    void Start()
    {
        turnOffCursor();
    }

    void turnOffCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void turnOnCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
