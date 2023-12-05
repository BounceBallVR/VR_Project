using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public GameObject[] gamebell = new GameObject[9];
    public float Speed = 2f;
    private int a = 2;
    private int fool = 0;
    private bool key;
    int a_a = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        key = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Speed = 50;
            a_a = 0;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Speed = 50;
            a_a = 1;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Speed = 50;
            a_a = 2;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Speed = 50;
            a_a = 3;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Speed = 50;
            a_a = 4;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Speed = 50;
            a_a = 5;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Speed = 50;
            a_a = 6;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Speed = 50;
            a_a = 7;
            key = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Speed = 50;
            a_a = 8;
            key = true;
        }

        if (key)
        {
            gamebell[a_a].transform.position += new Vector3(0, 0, -a) * Speed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("fool"))
        {
            if (fool == 0)
            {
                fool = 1;
                Debug.Log("1");
                a = a * -1;
            }
            else
            { 
                fool = 0;
                Speed = 0;
                a = a * -1;
            }
            
        }
    }
}
