using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroying : MonoBehaviour
{
    private Collider myCollider;
    
    void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    public void Destroyer(GameObject gameObject)
    {
        Destroy(myCollider);
        Object.Destroy(gameObject, 1f);
    }
}