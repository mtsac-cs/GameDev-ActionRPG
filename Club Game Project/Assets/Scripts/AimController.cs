using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Vector3 mousePos;

    private void Awake()
    {
        // Cursor will be confined to the game window indefinitely
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        // Grabs all the axis positions of the mouse, gets the absolute value of the z axis, and adds 1 to the z axis in order to show the reticle infront of the camera
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Input.mousePosition.z + 1));

        // Transforms the attached game object from screen space to world space, but because it uses the cameras z position which is at -1, the z axis of the reticle is at -1, therefore it will not 
        // show up in the game by default. This is why above we zeroed out the z position of the mouse, and added 1
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
