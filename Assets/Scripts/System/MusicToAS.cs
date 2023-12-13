using UnityEngine;
using System.Collections;

public class MusicToAS : MonoBehaviour
{
    public AudioSource audio_;
    string preMusic;
    string nowMusic;

    private void Awake()
    {
        preMusic = "";
        audio_ = GetComponent<AudioSource>();
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
            audio_.clip = Resources.Load(temp) as AudioClip;
            Debug.Log(temp);
        }
    }
}
