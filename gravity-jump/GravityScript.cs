// NOTE: This script applies gravitational force ONLY to
// Dynamic Rigidbody2D objects in the current scene.

// IMPORTANT: The object to which this script is attached
// must NOT be a dynamic object.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float strength;

    private List<Rigidbody2D> rigidbodies;
    private Rigidbody2D planetRb; // Rigidbody2D of the planet.

    private void Start()
    {
        rigidbodies = FindObjectsOfType<Rigidbody2D>().ToList(); // Find all Rigidbody2D components in the scene and convert them to a List.
        planetRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D rb in rigidbodies)
        {
            // Only apply gravitational force if the body is dynamic.
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                Vector2 force = Vector2.zero;
                float rbMass = rb.mass;

                Vector2 direction = planetRb.position - rb.position;
                float distanceSquared = direction.sqrMagnitude;
                if (distanceSquared == 0) continue; // Avoid division by zero

                force = direction.normalized * (strength * rbMass / distanceSquared);
                rb.AddForce(force);
            }
        }
    }
}
