using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RHand : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = ARAVRInput.RHand.parent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.position = ARAVRInput.RHandPosition+ARAVRInput.RHand.up*0.5f;
        transform.rotation=ARAVRInput.RHand.rotation*Quaternion.Euler(0,0,90);
    }
}
