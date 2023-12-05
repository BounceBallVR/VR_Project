using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball2 : MonoBehaviour
{
    public GameObject bullet_r;
    public GameObject PC_r;

#if Oculus
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger,ARAVRInput.Controller.LTouch))
        {
            Instantiate(bullet_r, transform.position, transform.rotation);
        }
    }
#endif
}
