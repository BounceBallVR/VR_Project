using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    public GameObject note0;
    public Transform Spawn0;
    public Transform Spawn1;

    float timer0 = 0;
    float timer1 = 0;
    float randomNum0;
    float randomNum1;
    // Start is called before the first frame update
    void Start()
    {
        randomNum0 = Random.Range(10f, 20f) / 10f;
        randomNum1 = Random.Range(10f, 20f) / 10f;
    }
    private void FixedUpdate()
    {
        timer0 += Time.fixedDeltaTime;
        timer1 += Time.fixedDeltaTime;
        if (timer0 > randomNum0)
        {
            timer0 = 0;
            GameObject A = Instantiate(note0, transform.position,Quaternion.Euler(Random.Range(0f,2f), Random.Range(0f, 1f), 0));
            A.transform.SetParent(transform);
            A.transform.position = Spawn0.transform.position;
            randomNum0 = Random.Range(10f, 20f) / 10f;
        }
        if (timer1 > randomNum1)
        {
            timer1 = 0;
            GameObject B= Instantiate(note0, transform.position, Quaternion.Euler(Random.Range(0f, 2f), Random.Range(0f, 1f), 0));
            B.transform.SetParent(transform);
            B.transform.position = Spawn1.transform.position;
            randomNum1 = Random.Range(10f, 20f) / 10f;
        }
    }
}
