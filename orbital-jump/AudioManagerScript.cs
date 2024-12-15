using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // The singleton instance

    public AudioSource thrusterLeft;
    public AudioSource thrusterRight;
    public AudioSource sfx;
    public AudioClip thrusterClip;
    public AudioClip explosion;
    public AudioClip button1;
    public AudioClip button2;

    private int fadeDirection = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float fadeSpeed = 3;
        thrusterLeft.volume += fadeDirection * fadeSpeed * Time.deltaTime;
        if (thrusterLeft.volume < 0.1)
        {
            thrusterLeft.Stop();
        }
        thrusterRight.volume += fadeDirection * fadeSpeed * Time.deltaTime;
        if (thrusterRight.volume < 0.1)
        {
            thrusterLeft.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void PlaySoundWithFade(AudioSource source, AudioClip clip)
    {
        fadeDirection = 1;
        source.PlayOneShot(clip);
    }

    public void StopSoundWithFade(AudioSource source)
    {
        fadeDirection = -1;
    }
}
