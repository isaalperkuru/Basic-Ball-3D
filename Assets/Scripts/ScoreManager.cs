using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;

    private TimeManager2 timeManager;

    public int GetScore
    {
        get
        {
            return score;
        }
    }
    private void Awake()
    {
        timeManager = GameObject.FindObjectOfType<TimeManager2>().GetComponent<TimeManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTheScore();
    }

    private void UpdateTheScore()
    {
        scoreText.text = "Score: " + score.ToString() + "/" + timeManager.GetScoreToWin.ToString();
    }
}
