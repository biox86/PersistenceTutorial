#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string username;
    public int highscore;
    public string highscoreUsername;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }

    public void startGame() {
        SceneManager.LoadScene("main");
    }

    public void updateUsername(string value) {
        username = value;
        Save();
    }

    public void exitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }


    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string highscoreUsername;
        public string lastUserame;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highscore = highscore;
        data.highscoreUsername = highscoreUsername;
        data.lastUserame = username;

        string json = JsonUtility.ToJson(data);    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscore = data.highscore;
            highscoreUsername = data.highscoreUsername;
            username = data.lastUserame;
        } else {
            highscore = 0;
            highscoreUsername = "";
            username = "";
        }
    }
}
