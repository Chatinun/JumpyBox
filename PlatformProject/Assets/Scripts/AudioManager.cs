using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audio;
    [SerializeField] private AudioSource audioSource;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void audioPlay(string soundname)
    {
        switch (soundname)
        {
            case "Jump":
                audioSource.PlayOneShot(audio[0]);
                break;
            case "Dead":
                audioSource.PlayOneShot(audio[1]);
                break;
            case "Bounce":
                audioSource.PlayOneShot(audio[2]);
                break;
            case "Key":
                audioSource.PlayOneShot(audio[3]);
                break;
            case "JumpToken":
                audioSource.PlayOneShot(audio[4]);
                break;
            case "LevelComplete":
                audioSource.PlayOneShot(audio[5]);
                break;
            case "MissingKey":
                audioSource.PlayOneShot(audio[6]);
                break;
            case "MouseHover":
                audioSource.PlayOneShot(audio[7]);
                break;

        }

    }

    public void PlayMouseHoverAudio()
    {
        audioSource.PlayOneShot(audio[7]);
    }
}
