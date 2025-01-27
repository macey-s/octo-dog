using UnityEngine;

public class TransformController : MonoBehaviour
{
    private void Update()
    {
        //Move the target GameObject
        var x = Mathf.PingPong(Time.time, 3);
        transform.position = new Vector3(x, 0, 0);
        var p = new Vector3(0, x, 0);
        transform.position = p;
        
        //Rotate the GameObject
        transform.Rotate(new Vector3(30, 60, 20) * Time.deltaTime);
    }
}