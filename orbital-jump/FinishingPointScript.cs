using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingPointScript : MonoBehaviour
{
    public float minAttractionDistance; // The minimum distance between the player to attract.
    public float attractionStrength;

    private GameObject player;
    private Rigidbody2D playerRb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= minAttractionDistance)
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
