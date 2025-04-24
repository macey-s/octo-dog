using UnityEngine;

public class attatchScript : MonoBehaviour
{
    private bool isCollected = false;
    public Vector3 offset = new Vector3(0.5f, 0.5f, 0f); // Where key appears relative to player

    private Transform player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            player = other.transform;
            isCollected = true;

            // Disable collider to avoid re-triggering
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void LateUpdate()
    {
        if (isCollected && player != null)
        {
            transform.position = player.position + offset;
        }
    }
}