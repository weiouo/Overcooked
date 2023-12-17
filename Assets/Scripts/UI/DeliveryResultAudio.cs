using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryResultAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip successAudio;
    public AudioClip unsuccessAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySuccessAudio()
    {
        audioSource.PlayOneShot(successAudio, 1f);
    }
    public void PlayUnsuccessAudio()
    {
        audioSource.PlayOneShot(unsuccessAudio, 1f);
    }
}
