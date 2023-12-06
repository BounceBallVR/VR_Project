using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instanse;
    [Header("#GameObj")]
    public BallBounce Ball;

    [Header("#Manager")]
    public BounceManager bounceManager;
    public CameraManager cameraManager;
    [Header("#Wall")]
    public GameObject front;
    public GameObject back;

    private void Awake()
    {
        instanse = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
