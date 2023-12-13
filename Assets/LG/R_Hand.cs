using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Hand : MonoBehaviour
{
    public GameObject PC_Rhand;
    public enum Hand
    {
        Left,
        Right
    }
    public Hand hand;
    //public GameObject A;

#if Oculus
    // Start is called before the first frame update
    void Start()
    {
        switch (hand)
        {
            case Hand.Left:
                transform.parent = ARAVRInput.LHand;
                transform.position = transform.parent.transform.position;
                transform.rotation=ARAVRInput.LHand.rotation*Quaternion.Euler(60,0,0);
                break;
            case Hand.Right:
                transform.parent = ARAVRInput.RHand;
                transform.position = transform.parent.transform.position;
                transform.rotation=ARAVRInput.RHand.rotation * Quaternion.Euler(60, 0, 0);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
#endif

    public void HandVive()
    {
        if (hand == Hand.Left)
        {
            ARAVRInput.PlayVibration(0.06f, 1, 1, ARAVRInput.Controller.LTouch);
        }
        else
            ARAVRInput.PlayVibration(0.06f, 1, 1, ARAVRInput.Controller.RTouch);
    }
}

