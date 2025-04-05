using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        // Applies force to object//
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 500);
        
        // Ground applies force to object//
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collision detected with " + collision.gameObject.name);
        }
    }
}

