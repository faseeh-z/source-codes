using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingPointScript : MonoBehaviour
{
    private float minAttractionDistance = 1.75f; // The minimum distance between the player to attract.
    private float attractionStrength = 20f;

    private GameObject player;
    private Rigidbody2D playerRb;
    private PlayerScript playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerScript>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= minAttractionDistance && playerScript.playerIsAlive)
        {
            Vector3 direction = (transform.position - player.transform.position);
            direction.Normalize();

            float strength = (minAttractionDistance - distance) * attractionStrength;
            strength *= strength;
            Vector2 force = new Vector2(direction.x * strength, direction.y * strength);
            playerRb.AddForce(force);
        }
    }
}
