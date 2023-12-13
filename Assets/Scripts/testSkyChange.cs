using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSkyChange : MonoBehaviour
{
    public Material[] SkyBoxs;
    public int skyNum=0;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = SkyBoxs[skyNum];
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox = SkyBoxs[skyNum];
    }
}
