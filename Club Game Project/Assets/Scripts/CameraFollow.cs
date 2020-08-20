using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private GameObject reticle;
    private Vector3 reticlePos;
    private Vector3 playerPos;
    private Vector3 relativePos;

    private void Awake()
    {
        player = GameObject.Find("Player");

        reticle = GameObject.Find("Reticle");
    }

    private void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, (player.transform.position.z - 1));

        reticlePos = new Vector2(reticle.transform.position.x, reticle.transform.position.y);

        Camera.main.WorldToScreenPoint(playerPos);
        Camera.main.WorldToScreenPoint(reticlePos);

        relativePos = (reticlePos - playerPos) / 3;
        Debug.DrawRay(playerPos, relativePos);

        transform.position = relativePos + playerPos;
        Debug.Log(relativePos + playerPos);
    }
}