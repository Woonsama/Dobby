using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using TextEditor = UnityEditor.UI.TextEditor;
#endif
[Serializable]
public struct Record
{
    public string name;
    public int score;
}

[Serializable]
public class RecordData
{
    // 1 ~ 10까지 오름차순
    public List<Record> records = new List<Record>();

    public void Add(Record data)
    {
        SortData();
        if (records.Count < 5)
            records.Add(data);
        else if (records[0].score < data.score)
        {
            records[0] = data;
            SortData();
        }
    }

    public void SortData()
    {
        records.Sort(delegate(Record data, Record data1)
        {
            if (data.score > data1.score) return 1;
            if (data.score < data1.score) return -1;
            return 0;
        });
    }
}

public class RecordViewer : MonoBehaviour
{
    public string filename;
    public InputField namebox;
    public Text ranking_view;
    private RecordData data;

    private void Start()
    {
        ShowRankText();
    }

    void Awake()
    {
        string filepath = Application.persistentDataPath + filename;
        if (System.IO.File.Exists(filepath))
        {
            string strdata = System.IO.File.ReadAllText(filepath);
            data = JsonUtility.FromJson<RecordData>(strdata);
        }
        else
        {
            data = new RecordData();
        }
    }

    public void AddData()
    {
        Record r = new Record();
        r.name = namebox.text;
        r.score = Score.Get().GetScore();
        data.Add(r);
        ShowRankText();
        Save();
    }

    public void ShowRankText()
    {
        ranking_view.text = MakeRankString();
    }

    private void Save()
    {
        string strjson = JsonUtility.ToJson(data);
        string filepath = Application.persistentDataPath + filename;
        System.IO.File.WriteAllText(filepath, strjson);
    }

    private string MakeRankString()
    {
        string result = "";
        int rank = 1;
        for (int i = data.records.Count - 1; i >= 0; i--)
        {
            result += String.Format("{0:D}등.{1:D}:{2}\n", rank, data.records[i].score, data.records[i].name);
            rank++;
        }

        return result;
    }
}
