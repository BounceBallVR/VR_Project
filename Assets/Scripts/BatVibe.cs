using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatVibe : MonoBehaviour
{
    public GameObject hand;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hand.GetComponent<R_Hand>().HandVive();
        }
    }
}
