using UnityEngine;
using System.Collections;

public class MusicToAS : MonoBehaviour
{
    AudioSource audio;
    string preMusic;
    string nowMusic;

    private void Awake()
    {
        preMusic = "";
        audio = GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("Music"))
            nowMusic = "Alone";
        else
            nowMusic = PlayerPrefs.GetString("Music");
    }

    private void Update()
    {
        nowMusic = PlayerPrefs.GetString("Music");
        if (preMusic != nowMusic)
        {
            preMusic = nowMusic;
            string temp = "Music/" + nowMusic;
            audio.clip = Resources.Load(temp) as AudioClip;
            audio.Play();
            Debug.Log(temp);
        }
    }
}
