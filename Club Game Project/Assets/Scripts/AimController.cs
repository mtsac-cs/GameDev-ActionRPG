using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private bool cursorIsVisible;

    private GameObject player; // Used in this script to grab the players location

    private Vector2 relativeLocation; // Calculates the local position of the cursor around the player

    private float angle; // the angle that the cursor is at with the player being at the origin

    void Start()
    {
        // assign the player gameobject. IMPORTANT: Do not change the player gameobject name unless you also change the name here
        player = GameObject.Find("Player");

        // on begin play, cursor will be invisible. Toggle in inspector during play to see the cursor
        cursorIsVisible = Cursor.visible = false; 
    }

    void Update()
    {
        // Subtracts the player position from the mouse position to get the local position of the cursor
        relativeLocation = Input.mousePosition - Camera.main.WorldToScreenPoint(player.transform.position); 

        // Finds the tan length of the y and x vectors, converts it to degrees from radians, and subtracts 90 to make the above-player-head position equal 0 degrees
        angle = (float)Mathf.Atan2(relativeLocation.y, relativeLocation.x) * Mathf.Rad2Deg - 90; // 

        // takes itself and divides by 90, rounds to the nearest integer, and times by 90
        angle = Mathf.RoundToInt(angle / 90) * 90;

        // rotates the object around the parent object at perfect 90 degree angle increments
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
