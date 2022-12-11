using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int highScore; // new variable declared
    public string player;
    public string highScorePlayer;
    //public int score;

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayer = highScorePlayer;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScorePlayer = data.highScorePlayer;
            highScore = data.highScore;
        }
    }

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    public void SetHighScore(int score){
        highScore = score;
        highScorePlayer = player;
        SaveHighScore();
    }
}
