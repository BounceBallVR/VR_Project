using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    public GameObject musicButton;
    public Transform buttonGroup;

    public static MainManager instance;

    public GameObject audioVis;
    public GameObject[] panels;
    //0: MainMid, 1: MainLeft, 2: MainRIght, 3: SettingMid, 4: SettingLeft
    //5: SettingRight, 6: TutorialOK, 7: ExitOK, 8: MusicMid, 9: MusicLeft
    //10: MusicRight
    //string selectedMusic = "GetUgly"; //temp name

    string[] kPopList = { "내가 제일 잘나가 - 2ne1", "질풍가도 - 유정석", "요구르팅 - 신지"};
    string[] popList = { "Water Me - Lizzo"}; 
    string[] elecList = { "Alone - Marshmello"};
    int buttons = 0;

    private void Awake()
    {
        instance = this;
        MainOpen();

        //new buttons
        for (int i = 0; i < kPopList.Length; i++)
        {
            GameObject obj = Instantiate(musicButton, buttonGroup);
            string[] tempName = kPopList[i].Split('-');
            obj.name = tempName[0].TrimEnd();
            obj.GetComponentInChildren<TextMeshProUGUI>().text = kPopList[i];
        }
        buttons = kPopList.Length;
    }


    void CloseAllPanel()
    {
        for (int i = 0; i < panels.Length; i++)
            panels[i].SetActive(false);
    }

    public void MainOpen()
    {
        CloseAllPanel();
        for (int i = 0; i < 3; i++) {
            panels[i].SetActive(true);

        }
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
        CloseAllPanel();
        panels[7].SetActive(true);
    }

    public void TutoPress()
    {
        CloseAllPanel();
        panels[6].SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("RoomMap");
    }

    public void KPOPClick()
    {
        MakeButtons(kPopList);
        Debug.Log("Kpop selected");
    }

    public void POPClick()
    {
        MakeButtons(popList);
        Debug.Log("Pop selected");
    }

    public void ElecClick()
    {
        MakeButtons(elecList);
        Debug.Log("Elec selected");
    }

    void MakeButtons(string[] s)
    {
        int n = buttons >= s.Length ? buttons : s.Length;
        //부족한 개수만큼 추가 생성
        for(int i = 0; i < n - buttons; i++)
        {
            Instantiate(musicButton, buttonGroup);
        }

        for(int i = 0; i < s.Length; i++)
        {
            GameObject obj =  buttonGroup.GetChild(i).gameObject;
            string[] tempName = s[i].Split('-');
            obj.name = tempName[0].TrimEnd();
            obj.SetActive(true);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = s[i];
        }
        for(int i = s.Length; i < n; i++)
        {
            GameObject obj = buttonGroup.GetChild(i).gameObject;
            obj.SetActive(false);
        }
        buttons = n;
    }
}
