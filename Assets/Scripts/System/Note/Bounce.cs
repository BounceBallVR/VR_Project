using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Vector3 pos;
    public Vector3 deltaPos;
    public AudioSource audio;
    Vector3 raydec=Vector3.zero;
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
            collision.gameObject.layer = LayerMask.NameToLayer("BombNote");
            Vector3 ballVec = collision.gameObject.GetComponent<BallBounce>().directionVec;
            Vector3 reflect = Vector3.Reflect(ballVec,transform.forward).normalized;
            //Vector3 reflect = Vector3.Reflect(ballVec, collision.contacts[0].normal).normalized;
            collision.gameObject.GetComponent<BallBounce>().directionVec = (reflect).normalized;
            collision.gameObject.GetComponent<BallBounce>().speed += Mathf.Abs(deltaPos.magnitude*300);
            collision.gameObject.GetComponent<BallBounce>().Block.startColor = new Color(0,68/255f,1f);
            if (audio != null)
            {
                audio.Play();
                StartCoroutine(PlayAttack());
            }
        }
    }
    IEnumerator PlayAttack()
    {
        yield return new WaitForSeconds(1);
        audio.Stop();
    }
}
