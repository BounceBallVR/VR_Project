using UnityEngine;
using System.IO;
using System.Collections;

public class NoteMaker : MonoBehaviour
{
    public GameObject[] beat;  //Make
    public GameObject[] beat_;  //Read 
    public string musicName = "";

    //AudioClip audio_;
    AudioSource asource_;

    bool[] flag = { false, false, false, false };

    public float timmer = 0;
    public float musicLength = 0;
    public float delay = 0.5f;

    string noteA, noteB, noteC, noteD = "";
    string[] noteA_, noteB_, noteC_, noteD_;
    string saving = "Assets/Resources/Notes/";

    private void Start()
    {
        //audio_ = GetComponent<AudioClip>();
        asource_ = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartRecord();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayRecord();
        }

        if (Input.GetKeyDown(KeyCode.D) && !flag[0])
        {
            flag[0] = true;
            noteA += "1 ";
            beat[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F) && !flag[1])
        {
            flag[1] = true;
            noteB += "1 ";
            beat[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.J) && !flag[2])
        {
            flag[2] = true;
            noteC += "1 ";
            beat[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K) && !flag[3])
        {
            flag[3] = true;
            noteD += "1 ";
            beat[3].SetActive(true);
        }
    }

    public void StartRecord()
    {
        //asource_.clip = Resources.Load("Music/" + PlayerPrefs.GetString("Music")) as AudioClip;
        asource_.clip = Resources.Load("Music/" + musicName) as AudioClip;
        //musicLength = audio_.length;
        musicLength = asource_.clip.length;
        Debug.Log("Record Start");
        StartCoroutine(RecordMusic());
    }

    public void PlayRecord()
    {
        //asource_.clip = Resources.Load("Music/" + PlayerPrefs.GetString("Music")) as AudioClip;
        asource_.clip = Resources.Load("Music/" + musicName) as AudioClip;
        //musicLength = audio_.length;
        musicLength = asource_.clip.length;
        Debug.Log("Record Play");
        StreamReader reader = new StreamReader(saving + musicName +".txt");
        string temp = reader.ReadToEnd();
        reader.Close();
        string[] tep = temp.Split("\n");
        noteA_ = tep[0].Split();
        noteB_ = tep[1].Split();
        noteC_ = tep[2].Split();
        noteD_ = tep[3].Split();
        StartCoroutine(PlayMusic());
    }

    IEnumerator RecordMusic()
    {
        for(int i = 0; i < musicLength / delay; i++)
        {
            yield return new WaitForSeconds(delay);
            if (!flag[0])
                noteA += "0 ";
            if (!flag[1])
                noteB += "0 ";
            if (!flag[2])
                noteC += "0 ";
            if (!flag[3])
                noteD += "0 ";
            for(int j = 0; j < 4; j++)
            {
                beat[j].SetActive(false);
                flag[j] = false;
            }
            timmer += delay;
        }

        StreamWriter sw = File.CreateText(saving + musicName + ".txt");
        string temp = noteA.TrimEnd() + "\n" + noteB.TrimEnd() + "\n" + noteC.TrimEnd() + "\n" + noteD.TrimEnd();
        sw.WriteLine(temp);
        sw.Flush();
        sw.Close();
        timmer = 0;
    }

    IEnumerator PlayMusic()
    {
        for (int i = 0; i < noteA_.Length; i++)
        {
             if (noteA_[i] == "1")
                beat_[0].SetActive(true);
            if (noteB_[i] == "1")
                beat_[1].SetActive(true);
            if (noteC_[i] == "1")
                beat_[2].SetActive(true);
            if (noteD_[i] == "1")
                beat_[3].SetActive(true);
            yield return new WaitForSeconds(delay);
            for(int j = 0; j < 4; j++)
                beat_[j].SetActive(false);
            timmer += delay;
        }
    }
}
