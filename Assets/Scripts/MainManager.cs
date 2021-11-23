using System;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
     public static MainManager Instance;

     public Color TeamColor;

     [Serializable]
     class SaveData
     {
          public Color TeamColor;
     }

     public void SaveColor()
     {
          SaveData saveData = new SaveData();
          saveData.TeamColor = TeamColor;
          
          string json = JsonUtility.ToJson(saveData);
          File.WriteAllText(Application.persistentDataPath+"/savefile.json",json);
     }

     public void LoadColor()
     {
          string path = Application.persistentDataPath + "/savefile.json";
          if (File.Exists(path))
          {
               string json = File.ReadAllText(path);
               var data = JsonUtility.FromJson<SaveData>(json);
               TeamColor = data.TeamColor;
          }
     }
     
     
     private void Awake()
     {
          if (Instance == null)
          {
               Instance = this;
               DontDestroyOnLoad(gameObject);
          }
     }
}
