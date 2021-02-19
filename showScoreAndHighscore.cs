using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showScoreAndHighscore : MonoBehaviour
{
    public Text scoreText, highScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("player_score").ToString();
        highScore.text = "Highscore: " + PlayerPrefs.GetInt("player_highscore").ToString();
    }
}
