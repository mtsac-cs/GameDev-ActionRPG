using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    //Method will run once the player is within enemy sights
    void OnTriggerEnter2D(Collider2D other)
    {
        //For future, add either an alert system, or just restart to last checkpoint
        Debug.Log("Player Detected");
    }
}
