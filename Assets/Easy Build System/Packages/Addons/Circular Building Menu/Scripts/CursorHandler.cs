using static UnityEngine.Cursor;
using static UnityEngine.CursorLockMode;

public static class CursorHandler
{
    public static void SetState(bool isLocked)
    {
        lockState = isLocked ? Locked : None;
        visible = !isLocked;
    }
}