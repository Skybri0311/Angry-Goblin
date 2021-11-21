using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour

{
    public static ScoreManager instance;

    public Text scoretext;
    public Text highscoretext;
    //Sets the starting values
    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    //Sets the Text to be Displayed
    void Start()
    {
        highscore = PlayerPrefs.GetInt("High Score", 0);
        scoretext.text = score.ToString() + "Points";
        highscoretext.text = "High Score" + highscore.ToString();
    }

    //Add Score to counter
    public void AddPoint()
    {
        score += 1;
        scoretext.text = score.ToString() + "Points";
        if (highscore < score)
        PlayerPrefs.SetInt("High Score", score);
    }
}
