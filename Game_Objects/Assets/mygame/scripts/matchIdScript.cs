using UnityEngine;

public class matchIdScript : MonoBehaviour
{
    public GameObject doorToOpen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            UnlockDoor(other.gameObject);
        }
    }

    void UnlockDoor(GameObject key)
    {
        doorToOpen.SetActive(false);
        Destroy(key);
        Debug.Log("Door unlocked!");
    }
}