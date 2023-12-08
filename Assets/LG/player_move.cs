using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    private Transform myTR;
    float H;
    float V;
    Vector3 myCevtor = Vector3.zero;
    float speed = 3.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        myTR = GetComponent<Transform>();
    }
#if Oculus
    // Update is called once per frame
    void Update()
    {
        
    }
}
#endif