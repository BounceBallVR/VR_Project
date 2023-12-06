using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject[] panels; 
    //0: MainMid, 1: MainLeft, 2: MainRIght, 3: SettingMid, 4: SettingLeft
    //5: SettingRight, 6: TutorialOK, 7: ExitOK, 8: MusicMid, 9: MusicLeft
    //10: MusicRight
    public GameObject[] music;

    public enum musics{
        WaterMe,
        GetUgly //temp
    }


    private void Awake()
    {
        instance = this;
        MainOpen();
    }

    void CloseAllPanel()
    {
        for (int i = 0; i < panels.Length; i++)
            panels[i].SetActive(false);
    }

    public void MainOpen()
    {
        CloseAllPanel();
        for (int i = 0; i < 3; i++)
            panels[i].SetActive(true);
    }

    public void SettingOn()
    {
        CloseAllPanel();
        for (int i = 3; i < 6; i++)
            panels[i].SetActive(true);
    }

    public void MusicOn()
    {
        CloseAllPanel();
        for (int i = 8; i < 11; i++)
            panels[i].SetActive(true);
    }

    public void ExitPress()
    {
        panels[7].SetActive(true);
    }

    public void TutoPress()
    {
        panels[6].SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
