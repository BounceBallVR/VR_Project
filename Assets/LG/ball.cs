using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float timmer = 0;
    public float BallSpeed = 5.0f;
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * BallSpeed);
        Destroy(gameObject, 3.0f);


    }

    private void FixedUpdate()
    {
        if (flag)
        {
            timmer += Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            flag = true;
        }
    }
}
