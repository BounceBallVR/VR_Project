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
                transform.parent = ARAVRInput.LHand;
                transform.rotation=ARAVRInput.LHand.rotation*Quaternion.Euler(60,0,0);
                gameObject.layer = LayerMask.NameToLayer("LeftNote");
                transform.position = transform.parent.transform.position;
                break;
            case Hand.Right:
                transform.parent = ARAVRInput.RHand;
                transform.rotation=ARAVRInput.RHand.rotation * Quaternion.Euler(60, 0, 0);
                gameObject.layer = LayerMask.NameToLayer("RightNote");
                transform.position = transform.parent.transform.position;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
   
#endif
}

