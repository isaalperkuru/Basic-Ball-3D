using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager2 : MonoBehaviour
{
    [SerializeField] private float levelLostTime = 20f;
    public bool isFinished = false;
    public bool gameOver = false;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();
    [SerializeField] private int scoreToWin = 1000;

    ScoreManager scoreManager;

    public int GetScoreToWin
    {
        get
        {
            return scoreToWin;
        }
    }
    private void Awake()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>();
        losePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }
        if (scoreManager.GetScore >= scoreToWin && gameOver == false)
        {
            losePanel.SetActive(false);
            winPanel.SetActive(true);
            isFinished = true;
            DestroyAllObjects();
        }
        if (gameOver || Time.timeSinceLevelLoad >= levelLostTime && isFinished == false)
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            DestroyAllObjects();
        }
    }

    private void DestroyAllObjects()
    {
        UpdateObjectList("Enemy");
        UpdateObjectList("Coin");
        foreach (GameObject allobjects in destroyAfterGame)
        {
            Destroy(allobjects);
        }
    }

    private void UpdateTheTimer()
    {
        timeText.text = "Countdown: " + (int)(levelLostTime - Time.timeSinceLevelLoad);
    }
    private void UpdateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }
}
