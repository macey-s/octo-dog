using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color newColor = Color.cyan;


    void OnCollisionEnter(Collision collision)
    {
        // Change the color on collision//
        GetComponent<Renderer>().material.color = newColor;
    }
}
