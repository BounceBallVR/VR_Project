using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSelect : MonoBehaviour
{
    string selectedMusic;

    public void MusicOn()
    {
        selectedMusic = this.gameObject.name;
        Debug.Log(selectedMusic);
        PlayerPrefs.SetString("Music", selectedMusic);
    }
}
