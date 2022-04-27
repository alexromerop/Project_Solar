using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader: MonoBehaviour
{
    public TextAsset textAssetData;

    int lineNum = 3;
    
    [System.Serializable]
    public class Dialogue
    {
        public string ID;
        public string engString;
        public string espString;
        public bool esp;
        public bool eng;
    }

    [System.Serializable]
    public class DialogueList
    {
        public Dialogue[] dialogue;
    }

    public DialogueList myDialogueList = new DialogueList();

    void Start()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / lineNum - 1;
        myDialogueList.dialogue = new Dialogue[tableSize];

        for(int i = 0; i < tableSize; i++)
        {
            myDialogueList.dialogue[i] = new Dialogue();
            myDialogueList.dialogue[i].ID = data[lineNum * (i + 1)];
            myDialogueList.dialogue[i].espString = data[lineNum * (i + 1) + 1];
            myDialogueList.dialogue[i].engString = data[lineNum * (i + 1) + 2];
            myDialogueList.dialogue[i].eng = false;
            myDialogueList.dialogue[i].esp = false;
        }
    }
}
