using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")] 
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;

    [Header("Score")] 
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreKeeper _scoreKeeper;

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _scoreKeeper.ResetScore();
    }
    
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = _scoreKeeper.GetScore().ToString("000000000"); 
    }
}
