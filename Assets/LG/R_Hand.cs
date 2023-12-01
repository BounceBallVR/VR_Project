using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject PC_Rhand;

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
        if(ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger,ARAVRInput.Controller.RTouch))
        {
           
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            ARAVRInput.PlayVibration(0.06f, 1, 1, ARAVRInput.Controller.RTouch);
            Debug.Log("hgf");
        }
    }
#endif
}

