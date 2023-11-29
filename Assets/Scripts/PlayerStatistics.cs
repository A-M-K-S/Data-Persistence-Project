using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStatistics : MonoBehaviour
{
    public static PlayerStatistics Instance;

    public string playerName;
    public string currentPlayer;
    public int playerScore;

    private void Awake()
    {
        if(PlayerStatistics.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string player;
        public int score;
    }

    public void SavePlayerStatistics()
    {
        SaveData data = new SaveData();
        playerName = currentPlayer;
        data.player = currentPlayer;
        data.score = playerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.player;
            playerScore = data.score;
        }   
    }
}
