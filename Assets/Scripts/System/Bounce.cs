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
        if (GameManager.instanse.bounceManager.R_Tounch)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        deltaPos = (transform.position - pos);
        pos = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !GameManager.instanse.bounceManager.R_Tounch)
        {
            GameManager.instanse.bounceManager.R_Tounch = true; 
            Vector3 reflect = Vector3.Reflect(GameManager.instanse.Ball.directionVec, collision.gameObject.transform.up).normalized;
            GameManager.instanse.Ball.directionVec = (reflect+deltaPos.normalized*5).normalized;
            GameManager.instanse.Ball.speed += Mathf.Abs(deltaPos.magnitude);        }
    }
}
