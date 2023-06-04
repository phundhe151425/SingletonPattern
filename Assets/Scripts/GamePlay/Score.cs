using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    int score;
    const string ScorePreFix = "Score: ";

    void Start()
    {
        scoreText.text = ScorePreFix + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePreFix + score.ToString();

    }
}
