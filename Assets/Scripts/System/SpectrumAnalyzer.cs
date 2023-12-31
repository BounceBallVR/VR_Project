﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Attach this script below a GameObject with an AudioSource and manually assign a clip and enable Play on Awake.
/// Since this script does not care what song is playing you can implement an Audio manager to change songs as you wish.
/// Make sure to manually assign two prefabs of your choice.
/// </summary>
public class SpectrumAnalyzer : MonoBehaviour
{
    public AnalyzerSettings settings; //All of our settings

    public bool dirr = false;
    public float depth = 0;
    //private
    private float[] spectrum; //Audio Source data
    private List<GameObject> pillars; //ref pillars to scale/move with music
    private GameObject folder;
    private bool isBuilding; //Prevents multi-calls and update while building.
    public int range = 100;

    Color[]  forest, winter;

    Color[] rainbow = { new Color(255, 0, 0), new Color(255, 51, 0), new Color(255, 102, 0), new Color(255, 153, 0), new Color(255, 204, 0), new Color(255, 255, 0),
                                      new Color(204, 255, 0), new Color(153, 255, 0), new Color(102, 255, 0), new Color(51, 255, 0), new Color(0, 255, 0),
                                      new Color(0, 255, 51), new Color(0, 255, 102), new Color(0, 255, 153), new Color(0, 255, 204), new Color(0, 255, 255),
                                      new Color(0, 204, 255), new Color(0, 153, 255), new Color(0, 102, 255), new Color(0, 51, 255), new Color(0, 0, 255),
                                      new Color(51, 0, 255), new Color(102, 0, 255), new Color(153, 0, 255), new Color(204, 0, 255), new Color(255, 0, 255),
                                      new Color(255, 0, 204), new Color(255, 0, 153), new Color(255, 0, 102), new Color(255, 0, 51)};

    public int Col = 1;

    void Start()
    {
        isBuilding = true;
        switch (Col)
        {
            case 1:
                CreatePillarsByShapes(rainbow);
                break;
            case 2:
                CreatePillarsByShapes(forest);
                break;
            case 3:
                CreatePillarsByShapes(winter);
                break;
            default:
                break;
        }
    }

    private void CreatePillarsByShapes(Color[] color)
    {
        //get current pillar types
        GameObject currentPrefabType = settings.pillar.type == PillarTypes.Cylinder ? settings.Prefabs.CylPrefab : settings.Prefabs.BoxPrefab;
       
        
        pillars = MathB.ShapesOfGameObjects(currentPrefabType, settings.pillar.radius, (int) settings.pillar.amount,settings.pillar.shape);

        //Organize pillars nicely in this folder under this transform
        folder = new GameObject("Pillars-" + pillars.Count);
        folder.transform.SetParent(transform);

        /*
        foreach (var piller in pillars)
        {
            piller.transform.SetParent(folder.transform);
            piller.GetComponent<MeshRenderer>().material.color = new Color(0, 255, 85);
        }
        */

        for (int i = 0; i < pillars.Count; i++)
        {
            GameObject piller = pillars[i];
            piller.transform.SetParent(folder.transform);
            piller.transform.name = "piller" + i;
            //piller.transform.position = new Vector3(0, depth, 0);
            Color myCol = color[i % color.Length];
            piller.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(myCol.r/255, myCol.g/255, myCol.b/255));
        }

        if (dirr)
        {
            for (int i = 0; i < pillars.Count/2; i++)
            {
                Vector3 poz = transform.GetChild(0).GetChild(i).transform.position;
                transform.GetChild(0).GetChild(i).transform.position = transform.GetChild(0).GetChild(pillars.Count - i - 1).transform.position;
                transform.GetChild(0).GetChild(pillars.Count - i - 1).transform.position = poz;
            }
        }


        isBuilding = false;

        if (dirr)
            this.gameObject.transform.localEulerAngles = new Vector3(0, range, 0);
        else
            this.gameObject.transform.localEulerAngles = new Vector3(0, -range, 0);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.R)) Rebuild();
        if (isBuilding) return;

        spectrum = AudioListener.GetSpectrumData((int) settings.spectrum.sampleRate, 0, settings.spectrum.FffWindowType);


        for (int i = 0; i < pillars.Count; i++) //needs to be <= sample rate or error
        {
            float level = spectrum[i]*settings.pillar.sensitivity*Time.deltaTime*1000; //0,1 = l,r for two channels

            //Scale pillars 
            Vector3 previousScale = pillars[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, level, settings.pillar.speed*Time.deltaTime);
                //Add delta time please
            pillars[i].transform.localScale = previousScale;

            //Move pillars up by scale/2
            Vector3 pos = pillars[i].transform.position;
            pos.y = previousScale.y*.5f;
            pillars[i].transform.position = pos;
        }
    }

    /// <summary>
    /// Called by UI slider onValue changed
    /// </summary>
    public void Rebuild()
    {
        if (isBuilding) return;

        //Destroy the pillars we had, clear the pillar list and start over
        isBuilding = true;
        pillars.Clear();
        DestroyImmediate(folder);
        CreatePillarsByShapes(rainbow);
    }

    /// <summary>
    /// Resets to all settings to default in inspector drop down.
    /// </summary>
    private void Reset()
    {
        settings.pillar.Reset();
        settings.spectrum.Reset();
    }

    #region Dynamic floats and for UI sliders

    /// <summary>
    /// Convert Shapes enum to an int from a float so we can control by UI Slider
    /// </summary>
    public float PillarShape
    {
        get { return (int) settings.pillar.shape; }
        set
        {
            //set with UI Slider
            int num = (int) Mathf.Clamp(value, 0, 3);
            settings.pillar.shape = (Shapes) num;
        }
    }

    public float PillarType
    {
        get { return (int) settings.pillar.type; }
        set
        {
            //set with UI Slider
            int num = (int)Mathf.Clamp(value, 0, 2); 
            settings.pillar.type = (PillarTypes) num;
        }
    }

    public float Amount
    {
        get { return settings.pillar.amount; }
        set
        {
            settings.pillar.amount = Mathf.Clamp(value, 4, 128);
            
        }
    }

    public float Radius
    {
        get { return settings.pillar.radius; }
        set { settings.pillar.radius = Mathf.Clamp(value, 2, 256); }
    }


    public float Sensitivity
    {
        get { return settings.pillar.sensitivity; }
        set { settings.pillar.sensitivity = Mathf.Clamp(value, 1, 50); }
    }

    public float PillarSpeed
    {
        get { return settings.pillar.speed; }
        set { settings.pillar.speed = Mathf.Clamp(value, 1, 30); }
    }


    public float SampleMethod
    {
        get { return (int) settings.spectrum.FffWindowType; }
        set
        {
            //set with UI Slider
            int num = (int)Mathf.Clamp(value, 0, 6); 
            settings.spectrum.FffWindowType = (FFTWindow) num;
        }
    }

    public float SampleRate
    {
        get { return (int) settings.spectrum.sampleRate; }
        set
        {
            //set with UI Slider
            int num = (int) Mathf.Pow(2, 7 + value);//128,256,512,1024,2056
            settings.spectrum.sampleRate = (SampleRates) num;
        }
    }

    #endregion
}