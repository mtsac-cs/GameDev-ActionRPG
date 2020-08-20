using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera mainCamera;
    private GameObject player;
    private Vector3 cameraPosition;

    private void Awake()
    {
        // Reference the main camera
        mainCamera = Camera.main;

        // Reference to the player game object. If you change the player game objects name, change this string to that new name in order to allow this script to reference the player
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        // Grabs all the axis positions of the player and subtracts 1 from the player's z axis
        cameraPosition = new Vector3(player.transform.position.x, player.transform.position.y, (player.transform.position.z - 1));

        // Assigns the above player position to the camera, except it subtracts 1 from the players position to always ensure the camera is in front of the player
        mainCamera.transform.position = cameraPosition;
    }
}
