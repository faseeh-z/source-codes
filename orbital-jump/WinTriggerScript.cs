using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinTriggerScript : MonoBehaviour
{
    public float stay; // How many seconds the player need to stay over the WinTrigger to win the game.
    private float startTime; // To calculate the elapsed time.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTime = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time - startTime > stay)
            {
                GameManager.Instance.CompleteLevel();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTime = 0f;
        }
    }
}
