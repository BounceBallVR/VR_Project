using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections;

public class CreateNote : MonoBehaviour
{
    public GameObject note;
    public Transform[] Spawns;

    public string musicName = "";



    public float musicLength = 0;
    public float delay = 0.5f;

    string[] noteA_, noteB_, noteC_, noteD_;
    string saving = "Assets/Resources/Notes/";


    public float timer = 0;
    private float timer_start = (float)System.DateTime.Now.TimeOfDay.TotalSeconds;
    public int NoteNum = 0;
    public float realtime =0;
    public float checktime = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
            musicName = "Alone";
        else
            musicName = PlayerPrefs.GetString("Music");
        PlayRecord();
    }
    private void FixedUpdate()
    {
        timer= (float)System.DateTime.Now.TimeOfDay.TotalSeconds - timer_start;
        if(timer>=delay*(NoteNum+1) && NoteNum<noteA_.Length)
        {
            if (noteA_[NoteNum] == "1")
                CreateNoteRay(0);
            if (noteB_[NoteNum] == "1")
                CreateNoteRay(1);
            if (noteC_[NoteNum] == "1")
                CreateNoteRay(2);
            if (noteD_[NoteNum] == "1")
                CreateNoteRay(3);
            NoteNum++;
        }
    }
    
    public void PlayRecord()
    {
        Debug.Log("Record Play");
        StreamReader reader = new StreamReader(saving + musicName + ".txt");
        string temp = reader.ReadToEnd();
        reader.Close();
        string[] tep = temp.Split("\n");
        noteA_ = tep[0].Split(" ");
        noteB_ = tep[1].Split(" ");
        noteC_ = tep[2].Split(" ");
        noteD_ = tep[3].Split(" ");
        delay = float.Parse(tep[4].Split(" ")[0]);
    }


    public void CreateNoteRay(int num)
    {
        GameObject AR = Instantiate(note, transform);
        AR.transform.SetParent(transform);
        AR.layer = LayerMask.NameToLayer("Note");
        AR.transform.position = Spawns[num].transform.position;
    }
}
