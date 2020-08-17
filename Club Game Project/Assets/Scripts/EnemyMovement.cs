using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variable Declaration
    private Vector3 initialSpawn;
    private bool moveUp;
    public Rigidbody2D rb;

    //Serialize Fields
    [SerializeField] private float _speed = 250f;

    private void Awake()
    {
        //Varibale Initialization
        initialSpawn = this.transform.position;
        moveUp = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //Set rigidbody values and options
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        //Run if enemy has moved 5 units up from start
        if(this.transform.position.y - initialSpawn.y > 5f)
        {
            //Set movement downward
            moveUp = false;
        }
        
        //Run if enemy has moved 5 units down from start
        else if(this.transform.position.y - initialSpawn.y < -5f)
        {
            //set movement upward
            moveUp = true;
        }
        
        //Set the velocity of the enemy to be either upward or downward with the set speed
        //NOTE: the Bool to Int conversion will act as multiplication of a 0 or a 1, so only one term will apply(Branchless Programming)
        rb.velocity = _speed * Time.deltaTime * (Vector3.up * Convert.ToInt32(moveUp) + Vector3.down * Convert.ToInt32(!moveUp));
    }
}
