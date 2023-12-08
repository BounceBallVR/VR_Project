using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
                transform.position = ARAVRInput.RHandPosition+ARAVRInput.RHand.up*0.1f;
                transform.Rotate(ARAVRInput.RHandPosition - transform.position);
                transform.parent = ARAVRInput.RHand;

                break;
            case Hand.Right:
                transform.position = ARAVRInput.LHandPosition + ARAVRInput.LHand.up * 0.1f;
                transform.Rotate(ARAVRInput.LHandPosition - transform.position);
                transform.parent = ARAVRInput.LHand;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
#endif
}

