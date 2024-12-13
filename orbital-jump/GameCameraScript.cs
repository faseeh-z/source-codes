using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCameraScript : MonoBehaviour
{
    [Range(0f, 1f)]
    public float smoothSpeed; // For Camera Smoothing.

    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 targetPosition;
        targetPosition.x = (player.transform.position.x - transform.position.x) * smoothSpeed;
        targetPosition.y = (player.transform.position.y - transform.position.y) * smoothSpeed;
        targetPosition.z = transform.position.z;
        transform.position = targetPosition;
    }
}
