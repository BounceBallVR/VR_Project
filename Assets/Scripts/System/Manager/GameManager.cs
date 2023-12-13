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
    [Header("#Music")]
    public MusicToAS musicToAs1;
    public MusicToAS musicToAs2;
    public GameObject videoToPlayer;

    [Header("#Game")]
    public float Score=0;
    public TextMeshProUGUI ScoreBoard;
    public TextMeshProUGUI BestScoreBoard;
    private void Awake()
    {
        instanse = this;
        ScoreBoard.text = "Score \n" + 0;
        StartCoroutine(DelayMusic());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        ScoreBoard.text = "Score \n"+(int)Score;
        BestScoreBoard.text = "Best\nScore\n" + PlayerPrefs.GetInt(PlayerPrefs.GetString("Music"));
    }

    IEnumerator DelayMusic()
    {
        yield return new WaitForSeconds(4.1f);
        musicToAs1.audio_.Play();
        musicToAs2.audio_.Play();
        videoToPlayer.GetComponent<VideoToPlayer>().video.Play();
    }
}
