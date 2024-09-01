using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText; // Reference to TextMeshPro component for the score


    private int score = 0; // The current score


    void Start()
    {
        UpdateScoreText();
    }

    // Add points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    // Updates the score text on the UI
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
