using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public enum CurrentMovement
{
    Idle = 0,
    Horizontal = 1,
    Vertical = 2
}

[RequireComponent (typeof (CapsuleCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 300;

    CapsuleCollider2D playerCapsuleCollider;
    Rigidbody2D playerRigidBody;

    Vector2 idle = Vector2.zero;
    Vector2 horizontalDirection;
    Vector2 verticalDirection;

    private float horizontalInput;
    private float verticalInput;

    CurrentMovement currentMovement;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {
        playerRigidBody.gravityScale = 0;
        playerRigidBody.freezeRotation = true;

        playerCapsuleCollider.size = new Vector2(1, 2);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        horizontalDirection = new Vector2(horizontalInput, 0);
        verticalDirection = new Vector2(0, verticalInput);

        UpdateMoveState();
    }

    private void FixedUpdate()
    {
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

    private void UpdateMovement(Vector2 updatedDirection)
    {
        playerRigidBody.velocity = updatedDirection.normalized * _speed * Time.deltaTime;
    }

    private void UpdateMoveState()
    {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                currentMovement = CurrentMovement.Horizontal;
                Debug.Log("Horizontal 1");
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                currentMovement = CurrentMovement.Vertical;
                Debug.Log("Vertical");
            }
    }
}

