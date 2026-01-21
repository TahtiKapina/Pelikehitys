using UnityEngine;
using TMPro;

public class ClickerManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;

    private int score = 0;

    void Start()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        highscoreText.text = "Highscore: " + highscore;
        UpdateScoreText();
    }

    public void Click()
    {
        score++;
        UpdateScoreText();
    }

    #region Tähän tulee EndGame-metodi



    #endregion

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
