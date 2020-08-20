using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    NOTE: Unity recommends to adjust Time.fixedDeltaTime as well, however
    I will leave this unaltered for now. If problems arise in the future,
    with the pause system we can try this solution.

    ALSO NOTE: Pausing will lock the cursor to the game window. Just press
    escape again to unlock the cursor during play
 */

public class Pause : MonoBehaviour
{
    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1f && Cursor.visible == false)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }
    }
}
