using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNote : MonoBehaviour
{
    public GameObject noteL;
    public GameObject noteR;
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
            if (Random.Range(0, 2) == 0)
            {
                GameObject AL = Instantiate(noteL, transform.position,Quaternion.Euler(Random.Range(0f,2f), Random.Range(0f, 1f), 0));
                AL.transform.SetParent(transform);
                AL.layer = LayerMask.NameToLayer("LeftNote");
                AL.transform.position = Spawn0.transform.position;
            }
            else
            {
                GameObject AR = Instantiate(noteR, transform.position,Quaternion.Euler(Random.Range(0f,2f), Random.Range(0f, 1f), 0));
                AR.transform.SetParent(transform);
                AR.layer = LayerMask.NameToLayer("RightNote");
                AR.transform.position = Spawn0.transform.position;
            }
            randomNum0 = Random.Range(10f, 20f) / 10f;
        }
        if (timer1 > randomNum1)
        {
            timer1 = 0; 
            if (Random.Range(0, 2) == 0)
            {
                GameObject AL = Instantiate(noteL, transform.position, Quaternion.Euler(Random.Range(0f, 2f), Random.Range(0f, 1f), 0));
                AL.transform.SetParent(transform);
                AL.layer = LayerMask.NameToLayer("LeftNote");
                AL.transform.position = Spawn1.transform.position;
            }
            else
            {
                GameObject AR = Instantiate(noteR, transform.position, Quaternion.Euler(Random.Range(0f, 2f), Random.Range(0f, 1f), 0));
                AR.transform.SetParent(transform);
                AR.layer = LayerMask.NameToLayer("RightNote");
                AR.transform.position = Spawn1.transform.position;
            }
            randomNum1 = Random.Range(10f, 20f) / 10f;
        }
    }
}
