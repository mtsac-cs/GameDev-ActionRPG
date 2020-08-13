using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

// Enum values which are used in a switch statement to change between the different movement states
public enum CurrentMovement
{
    Idle = 0,
    Horizontal = 1,
    Vertical = 2
}

// Upon attaching this script to a gameobject, these two components will automatically be attached with it.
[RequireComponent (typeof (CapsuleCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 300;

    // References to these two components
    CapsuleCollider2D playerCapsuleCollider;
    Rigidbody2D playerRigidBody;

    // the default raw direction vectors of the various movement states. These vectors are not noramlized or altered in any way.
    Vector2 idle = Vector2.zero;
    Vector2 horizontalDirection;
    Vector2 verticalDirection;

    // float values of up, down, left, right directions. Assigned to default settings in the Unity Input Manager System
    private float horizontalInput;
    private float verticalInput;

    // The referenced movement state
    CurrentMovement currentMovement;

    private void Awake()
    {
        // Assigns the references to the attached components
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        // Assigns various settings on the first frame of begin play
        playerRigidBody.gravityScale = 0;
        playerRigidBody.freezeRotation = true;
        playerCapsuleCollider.size = new Vector2(1, 2);
    }

    private void Update()
    {
        // Raw input numbers from Unity's Input Manager System
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Assigns the default raw direction vectors
        horizontalDirection = new Vector2(horizontalInput, 0);
        verticalDirection = new Vector2(0, verticalInput);

        // updates the movement based off the current state assigned
        UpdateMoveState();
    }

    private void FixedUpdate()
    {
        // a switch for the various movement states. Put inside FixedUpdate so movement can be calculated with Unity's physics system in mind
        switch (currentMovement)
        {
            case CurrentMovement.Idle:
                UpdateMovement(idle);
                break;
            case CurrentMovement.Horizontal:
                UpdateMovement(horizontalDirection);
                break;
            case CurrentMovement.Vertical:
                UpdateMovement(verticalDirection);
                break;
            default:
                UpdateMovement(idle);
                break;
        }
    }

    // Takes the current movement direction vector and normalizes, assigns speed to, and assigns Time.deltaTime to it
    private void UpdateMovement(Vector2 updatedDirection)
    {
        playerRigidBody.velocity = updatedDirection.normalized * _speed * Time.deltaTime;
    }

    // Basic logic behind the movement. Down side to this is that horizontal input takes priority.
    // We cannot override horizontal movement with vertical movement. We can, however, override vertical movement with horizontal movement. Will fix this later.
    private void UpdateMoveState()
    {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                currentMovement = CurrentMovement.Horizontal;
                Debug.Log("Horizontal");
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                currentMovement = CurrentMovement.Vertical;
                Debug.Log("Vertical");
            }
    }
}

