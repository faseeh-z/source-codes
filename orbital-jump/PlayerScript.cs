using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float thrust;
    public float torque;
    public Rigidbody2D rb;

    public InputAction leftThruster;
    public InputAction rightThruster;

    public ParticleSystem fuelTank;
    public ParticleSystem leftPS;
    public ParticleSystem rightPS;

    private bool playerIsAlive = true;

    // .Enable and .Disable are required for the new Input System.
    private void OnEnable()
    {
        leftThruster.Enable();
        rightThruster.Enable();
    }

    private void OnDisable()
    {
        leftThruster.Disable();
        rightThruster.Disable();
    }

    private void Update()
    {
        if (playerIsAlive)
        {
            {

            }
            if (leftThruster.ReadValue<float>() > 0)
            {
                rb.AddForce(transform.up * thrust);
                rb.AddTorque(-torque);
                if (!leftPS.isPlaying)
                {
                    leftPS.Play();
                }
            }
            else
            {
                if (leftPS.isPlaying)
                {
                    leftPS.Stop();
                }
            }

            if (rightThruster.ReadValue<float>() > 0)
            {
                rb.AddForce(transform.up * thrust);
                rb.AddTorque(torque);
                if (!rightPS.isPlaying)
                {
                    rightPS.Play();
                }
            }
            else
            {
                if (rightPS.isPlaying)
                {
                    rightPS.Stop();
                }
            }
        }
        else
        {
            if (leftPS.isPlaying)
            {
                leftPS.Stop();
            }
            if (rightPS.isPlaying)
            {
                rightPS.Stop();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == 6 && playerIsAlive) // Layer 6 = Terrain.
        {
            fuelTank.Play();
            playerIsAlive = false;
        }
    }
}
