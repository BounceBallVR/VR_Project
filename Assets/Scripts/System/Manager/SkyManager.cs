using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public Material[] SkyBoxs;
    public int SkyNum=0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SkyBox")){
            SkyNum = PlayerPrefs.GetInt("SkyBox");
        }
        RenderSettings.skybox = SkyBoxs[SkyNum];
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox = SkyBoxs[SkyNum];
    }
}
