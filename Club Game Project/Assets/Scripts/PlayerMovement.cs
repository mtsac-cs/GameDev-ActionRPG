using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

// Upon attaching this script to a gameobject, these two components will automatically be attached with it.
[RequireComponent (typeof (CapsuleCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 300;

    // References to these two components
    CapsuleCollider2D playerCapsuleCollider;
    Rigidbody2D playerRigidBody;

    Vector2 horizontalDirection;
    Vector2 verticalDirection;

    // float values of up, down, left, right directions. Assigned to default settings in the Unity Input Manager System
    private float horizontalInput;
    private float verticalInput;

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

    private void FixedUpdate()
    {
        // Raw input numbers from Unity's Input Manager System
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Assigns the default raw direction vectors
        horizontalDirection = new Vector2(horizontalInput, 0);
        verticalDirection = new Vector2(0, verticalInput);

        UpdateMovement(horizontalDirection, verticalDirection);
    }

    // Takes the current movement direction vector and normalizes, assigns speed to, and assigns Time.deltaTime to it
    private void UpdateMovement(Vector2 horizontalMovement , Vector2 verticalMovement)
    {
        playerRigidBody.velocity = (horizontalMovement.normalized + verticalMovement.normalized) * _speed * Time.deltaTime;
    }
}

