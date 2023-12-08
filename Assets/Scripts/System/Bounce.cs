using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Vector3 pos;
    public Vector3 deltaPos;
    private void Start()
    {
        pos = transform.position;
    }
    private void FixedUpdate()
    {
        deltaPos = (transform.position - pos);
        pos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") )
        {
            collision.gameObject.GetComponent<Collider>().enabled = false;
            Vector3 ballVec = collision.gameObject.GetComponent<BallBounce>().directionVec;
            Vector3 reflect = Vector3.Reflect(ballVec, collision.contacts[0].normal).normalized;
            collision.gameObject.GetComponent<BallBounce>().directionVec = (reflect).normalized;
            collision.gameObject.GetComponent<BallBounce>().speed += Mathf.Abs(deltaPos.magnitude*300);    
        }
    }
}
