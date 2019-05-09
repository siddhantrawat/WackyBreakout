using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{

    int score = 0;
    [SerializeField]
    Text scoreText;
    string prefixScore;

    [SerializeField]
    Text balls;
    string prefixballs;
    int ballRemaning;

    SpawnBallEvent spawnBallEvent = new SpawnBallEvent();
    LastBallLostEvent lastBallLostEvent = new LastBallLostEvent();
    
    // Use this for initialization
    void Start()
    {
        ballRemaning = ConfigurationUtils.TotalBalls;
        prefixScore = scoreText.text;
        scoreText.text = prefixScore + " 0";

        prefixballs = balls.text;
        balls.text = prefixballs + ballRemaning.ToString();

 
        EventManager.AddUpdateScoreListener(UpdateScore);
        EventManager.AddReduceBallListener(UpdateBallRemaing);
        EventManager.AddLastBallInvoker(this);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetScore()
    {
        return score;
    }
    public void UpdateScore(int scorePoints)
    {
        score = score + scorePoints;
        scoreText.text = prefixScore + score.ToString();
    }

    public void UpdateBallRemaing()
    {
        if (ballRemaning > 0)
        {
            ballRemaning = ballRemaning - 1;
            balls.text = prefixballs + ballRemaning.ToString();
            spawnBallEvent.Invoke();
            Debug.Log(ballRemaning);
        }
        else
        {
            lastBallLostEvent.Invoke();
        }
    }

    public void AddLastBallListener(UnityAction listener)
    {
        lastBallLostEvent.AddListener(listener);
    }
}
