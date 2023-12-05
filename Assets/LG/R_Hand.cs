using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject PC_Rhand;
    public GameObject A;

#if Oculus
    // Start is called before the first frame update
    void Start()
    {
        transform.position = ARAVRInput.RHandPosition;
        transform.rotation = ARAVRInput.RHand.rotation;
        transform.parent = ARAVRInput.RHand;
    }

    // Update is called once per frame
    void Update()
    {

    }
   
#endif
}

