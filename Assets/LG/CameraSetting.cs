using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{

    public GameObject PC_Camera;
    public GameObject Oculus_Camera;
    private void Awake()
    {
#if PC
        PC_Camera.SetActive(true);
#endif

#if Oculus
        Oculus_Camera.SetActive(true);
#endif

    }
}
