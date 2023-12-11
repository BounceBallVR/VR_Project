using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoToPlayer : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject lazer;

    VideoPlayer video;
    string preMusic;
    string nowMusic;

    double timmer = 0;
    [SerializeField]
    double endTime = 0;

    private void Awake()
    {
        lazer.SetActive(false);
        preMusic = "";
        video = GetComponent<VideoPlayer>();
        if (!PlayerPrefs.HasKey("Music"))
            nowMusic = "Alone";
        else
            nowMusic = PlayerPrefs.GetString("Music");
    }

    private void Start()
    {
        endPanel.SetActive(false);
        endTime = video.clip.length;
       
    }

    private void Update()
    {

        nowMusic = PlayerPrefs.GetString("Music");
        if (preMusic != nowMusic)
        {
            preMusic = nowMusic;
            string temp = "MusicVideo/" + nowMusic;
            video.clip = Resources.Load(temp) as VideoClip;
            video.Play();
            endTime = video.clip.length;
            Debug.Log(temp);
        }

        timmer += Time.deltaTime;

        if (timmer >= endTime)
        {
            endPanel.SetActive(true);
            lazer.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void BackMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainRoom");
    }
}
