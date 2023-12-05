using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vib : MonoBehaviour
{
    float speed;
   #if Oculus
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            speed = collision.gameObject.GetComponent<ball>().timmer;
            Debug.Log("speed: " + speed);
            if(speed <= 1.2f)
            {
                ARAVRInput.PlayVibration(0.5f, 1, 1, ARAVRInput.Controller.RTouch);
            }
            else
            {
                ARAVRInput.PlayVibration(0.1f, 1, 1, ARAVRInput.Controller.RTouch);
            }
            //Rigidbody otherRigidbody = gameObject.GetComponent<Rigidbody>();
            //if (otherRigidbody != null)
            //{
            //    Vector3 velocity = otherRigidbody.velocity;
            //    Debug.Log("¼Óµµ" + velocity);
            //}
        }
    }
#endif
}
