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
                transform.position = ARAVRInput.LHandPosition;
                transform.rotation=ARAVRInput.LHand.rotation*Quaternion.Euler(60,0,0);
                transform.parent = ARAVRInput.LHand;
                gameObject.layer = LayerMask.NameToLayer("LeftNote");
                break;
            case Hand.Right:
                transform.position = ARAVRInput.RHandPosition;
                transform.rotation=ARAVRInput.RHand.rotation * Quaternion.Euler(60, 0, 0);
                transform.parent = ARAVRInput.RHand;
                gameObject.layer = LayerMask.NameToLayer("RightNote");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
#endif
}

