using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HYJTest : MonoBehaviour
{
    private Transform aa;
    public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        aa = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        aa.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("fool"))
        {
            Debug.Log("ÂïÈû");
            speed = speed * -1;

        }
    }
}
