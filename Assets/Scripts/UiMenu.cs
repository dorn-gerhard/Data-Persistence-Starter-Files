using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UiMenu : MonoBehaviour
{
    public TMP_Text bestScore;
    public TMP_InputField enterText;
    
    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = "Best Score: " + GameManager.Instance.highScorePlayer + ": " + GameManager.Instance.highScore;
    }

    // Update is called once per frames
    void Update()
    {
        
    }

    public void StartGame()
    {  
        Debug.Log("player: " + enterText.text +", highScore: " + GameManager.Instance.highScore + ", highScorePlayer: " + GameManager.Instance.highScorePlayer);
        GameManager.Instance.player = enterText.text;
        SceneManager.LoadScene("main");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif 
    }
}
