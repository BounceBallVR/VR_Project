using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instanse;
    [Header("#GameObj")]
    public BallBounce Ball;
    public Transform BallSpawn;

    [Header("#Manager")]
    public BounceManager bounceManager;
    public CameraManager cameraManager;
    [Header("#Wall")]
    public GameObject front;
    public GameObject back;

    [Header("#ScoreText")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bsTxt;

    public float Score=0;
    float bestScore;
    private void Awake()
    {
        instanse = this;
        bestScore = (float)PlayerPrefs.GetInt(PlayerPrefs.GetString("Music"));
        bsTxt.text = "BEST\nSCORE\n" + bestScore;
    }
    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = "SCORE\n" + Score;
        if (Score > bestScore)
            PlayerPrefs.SetInt(PlayerPrefs.GetString("Music"), (int)Score);
    }
}
