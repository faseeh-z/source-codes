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

    public bool playerIsAlive = true;

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
        if (playerIsAlive && !GameManager.Instance.levelCompleted)
        {
            if (leftThruster.ReadValue<float>() > 0)
            {
                if (!leftPS.isPlaying)
                {
                    leftPS.Play();
                    AudioManager.Instance.PlaySoundWithFade(AudioManager.Instance.thrusterLeft, AudioManager.Instance.thrusterClip);
                }
                rb.AddForce(transform.up * thrust);
                rb.AddTorque(-torque);
            }
            else
            {
                if (leftPS.isPlaying)
                {
                    leftPS.Stop();
                    AudioManager.Instance.StopSoundWithFade(AudioManager.Instance.thrusterLeft);
                }
            }

            if (rightThruster.ReadValue<float>() > 0)
            {
                if (!rightPS.isPlaying)
                {
                    rightPS.Play();
                    AudioManager.Instance.PlaySoundWithFade(AudioManager.Instance.thrusterRight, AudioManager.Instance.thrusterClip);
                }
                rb.AddForce(transform.up * thrust);
                rb.AddTorque(torque);
            }
            else
            {
                if (rightPS.isPlaying)
                {
                    rightPS.Stop();
                    AudioManager.Instance.StopSoundWithFade(AudioManager.Instance.thrusterRight);
                }
            }
        }
        else
        {
            if (leftPS.isPlaying)
            {
                leftPS.Stop();
                AudioManager.Instance.StopSoundWithFade(AudioManager.Instance.thrusterLeft);
            }
            if (rightPS.isPlaying)
            {
                rightPS.Stop();
                AudioManager.Instance.StopSoundWithFade(AudioManager.Instance.thrusterRight);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == 6 && playerIsAlive) // Layer 6 = Terrain.
        {
            fuelTank.Play();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.explosion);
            playerIsAlive = false;
        }
    }
}
