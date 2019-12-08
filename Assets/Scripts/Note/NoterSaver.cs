using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System.Linq;

public class NoterSaver : MonoBehaviour
{
    public Noter noter;
    public string input;
    public string filename;


    public void Awake()
    {
        Debug.Log(filename);
        TextAsset tAsset =  Resources.Load<TextAsset>(input);
        string json = tAsset.text; 
                    
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, noter.data);
        Debug.Log(noter.data.notes.Count);
    }

    public void Save()
    {
        noter.makeData();
        string json = JsonUtility.ToJson(noter.data);
        Debug.Log(noter.data.notes.Count());
        Debug.Log(json);

        var path = Application.dataPath + "/NoteMaps/" + filename;
        Debug.Log(path);
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.Write(json);
            sw.Flush();
        }
    }
}
