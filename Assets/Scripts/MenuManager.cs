using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_Text highscore;

    private int bestScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance.username != "") {
            username.text = GameManager.Instance.username;
            highscore.text = "Best Score : " + GameManager.Instance.highscoreUsername + " : " + GameManager.Instance.highscore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeUsername() {
        GameManager.Instance.updateUsername(username.text);
    }
}
