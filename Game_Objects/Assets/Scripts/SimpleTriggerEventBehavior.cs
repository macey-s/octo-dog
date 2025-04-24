using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Trigger the event and test with debug message //
        if (other.gameObject.tag == "Player")
        {
            triggerEvent.Invoke();
            Debug.Log("You touched sum");
        }
    }
}