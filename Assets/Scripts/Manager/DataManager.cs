using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonMonoBehaviour<DataManager>
{
    public List<HighScoreData> highScoreDataList= new List<HighScoreData>();
    private string path = "";
    private string persistentPath = "";
    public int OldHighScore;

    private void Start()
    {
        SetPaths();
        if (GameManager.Instance.CurrentLevel == 1)
        {
            LoadData();
            SetOldHighScore();
        }
    }
    
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    private void CreateData()
    {
        //Trước khi tạo Data Save mới thì xóa dữ liệu cũ đi
        if (highScoreDataList.Count != 0 && highScoreDataList != null)
        {
            highScoreDataList.Clear();
        }
        
    }

    private void SetOldHighScore()
    {
        foreach (HighScoreData highScoreData in highScoreDataList )
        {
            OldHighScore = highScoreData.HighScore;
        }
    }
    
    public void SaveData(string playerName, int highScore)
    {
        CreateData();
        HighScoreData highScoreData= new HighScoreData(playerName, highScore);
        highScoreDataList.Add(highScoreData);
        /*string savePath = path;*/
        string savePath = persistentPath;
        
        Debug.Log("Save Data at: "+ savePath);
        SaveData saveData= new SaveData
        {
            //Tạo đối tượng SaveData để bao quanh danh sách previousLevelDataList
            HighScoreDataList = highScoreDataList
        };

        using StreamWriter writer= new StreamWriter(savePath);
        
        string json = JsonUtility.ToJson(saveData);
        Debug.Log(json);
            
        writer.WriteLine(json);
    }

    public void LoadData()
    {
        if (File.Exists(persistentPath))
        {
            using (StreamReader reader = new StreamReader(persistentPath))
            {
                string json = reader.ReadToEnd();

                // Chuyển đổi chuỗi JSON thành đối tượng SaveData
                SaveData saveData = JsonUtility.FromJson<SaveData>(json);

                highScoreDataList = saveData.HighScoreDataList;

                /*// Truy cập danh sách previousLevelDataList từ đối tượng SaveData
                foreach (PreviousLevelData data in saveData.PreviousLevelDataList)
                {
                    Debug.Log(data.ToString());
                }*/
            }
        }
        else
        {
            // Xử lý khi tệp tin không tồn tại
            SaveData("", 0);
        }
    }
}
