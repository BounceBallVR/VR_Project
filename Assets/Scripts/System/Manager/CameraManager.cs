using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject PC_Camera;
    public GameObject Oculus_Camera;

    // Start is called before the first frame update
    void Start()
    {
#if PC
        Oculus_Camera.SetActive(false);
        PC_Camera.SetActive(true);
#endif
#if Oculus
        Oculus_Camera.SetActive(true);
        PC_Camera.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
