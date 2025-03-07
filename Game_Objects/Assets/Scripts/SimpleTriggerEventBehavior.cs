using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        // Trigger the event and test with debug message //
        triggerEvent.Invoke();
        Debug.Log("Player interacted with the object!");
    }
}