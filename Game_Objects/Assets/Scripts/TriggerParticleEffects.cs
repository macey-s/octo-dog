using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particleSystem; // Reference to the Particle System
    public int particleAmount = 10; // Exposed variable for particle amount

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player triggered the event
        {
            particleSystem.Emit(particleAmount); // Emit the specified amount of particles
        }
    }
}