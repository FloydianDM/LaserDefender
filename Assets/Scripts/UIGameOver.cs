using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;

    void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreText.text = "You Scored:\n" + _scoreKeeper.GetScore();
    }
}
