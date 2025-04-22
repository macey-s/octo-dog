using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }

    public void OnClick()
    {
        audioSource.Pause();
    }

    public void OnClick2()
    {
        audioSource.UnPause();
    }
}