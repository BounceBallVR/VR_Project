using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoToPlayer : MonoBehaviour
{
    public GameObject endPanel;

    VideoPlayer video;
    string preMusic;
    string nowMusic;

    double timmer = 0;
    [SerializeField]
    double endTime = 0;

    private void Awake()
    {
        
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
            endPanel.SetActive(true);
    }

    public void BackMain()
    {
        SceneManager.LoadScene("MainRoom");
    }
}
