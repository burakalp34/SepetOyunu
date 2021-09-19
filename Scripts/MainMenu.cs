using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject TutorialText, TutorialExit;
    public bool ShowingTutorial = false, QuitMainMenu = false;
    public float Timer = 1f;
    public string HighScoreKey = "HSK";
    public int HighScore = 0;
    public UnityEngine.UI.Text HS;
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        HS.text = "High-Score: " + HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0f) {
            SceneManager.LoadScene("GameScene");
        }
    }
    private void FixedUpdate()
    {
        if (QuitMainMenu) {
            Timer -= Time.fixedDeltaTime;
        }
    }
    public void StartGame() {
        QuitMainMenu = true;
        if (ShowingTutorial)
        {
            TutorialText.SetActive(false);
            TutorialExit.SetActive(true);
            Timer = 1f;
        }
        else {
            Timer = 0f;
        }
    }
    public void Tutorial()
    {
        TutorialText.SetActive(true);
        TutorialExit.SetActive(false);
        ShowingTutorial = true;
    }
    public void Exit() {
        Application.Quit();
    }
}
