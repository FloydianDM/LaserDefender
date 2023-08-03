using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    private int _score;
    private static ScoreKeeper _instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return _score;
    }

    public void ModifyScore(int addedScore)
    {
        _score += addedScore;
        Mathf.Clamp(_score, 0, int.MaxValue);
        Debug.Log(_score);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
