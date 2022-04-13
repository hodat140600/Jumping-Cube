﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    static public ScoreManager Instance;
    private int score;
    private int scoreBest;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        scoreBest = PlayerPrefs.GetInt("SCOREBEST");
        UIManager.Instance.txtScoreBest.GetComponent<Text>().text = scoreBest.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public int GetScoreBest()
    {
        return scoreBest;
    }

    public void AddScore(int n)
    {
        score += n;
        if (scoreBest < score)
        {
            scoreBest = score;
            UIManager.Instance.txtScoreBest.GetComponent<Text>().text = scoreBest.ToString();
            // Save scoreBest 
            PlayerPrefs.SetInt("SCOREBEST", scoreBest);
        }
        //Debug.Log(score);
        UIManager.Instance.txtScore.GetComponent<Text>().text = score.ToString();
    }
}
