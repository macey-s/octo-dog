using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ✅ Only trigger if it's the player
        {
            audioSource.Play();
        }
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