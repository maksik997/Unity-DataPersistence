using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistance : MonoBehaviour
{
    public static Persistance Instance;

    public string CurrentPlayer;

    public string PlayerName;
    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        LoadScore();
    }

    public void UpdatePlayerName(string str)
    {
        CurrentPlayer = str;
    }

    public bool isScoreBeated(int n)
    {
        return Score < n;
    }

    public void UpdateScore(int points)
    {
        PlayerName = CurrentPlayer;
        Score = points;

        SaveScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Score;

        public SaveData(string name, int score)
        {
            this.PlayerName = name;
            this.Score = score;
        }
    }

    public void SaveScore()
    {
        SaveData data = new SaveData(PlayerName, Score);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            Score = data.Score;
        }
    }
}
