using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScore : MonoBehaviour
{
    int enemyScore;
    public Text enemyScoreText;
    int collectableScore;
    public Text collectableScoreText;
    int objectivesScore;
    int objectivesCount = 0;
    public Text objectivesScoreText;
    int finalScore;
    public Text finalScoreText;
    int bonus = 500;

    LevelManager instance;

    // Use this for initialization
    void Start()
    {
       instance = FindObjectOfType<LevelManager>();
        instance.livesText.CrossFadeAlpha(0.0f, 0.0f, false);
        instance.scoreText.CrossFadeAlpha(0.0f, 0.0f, false);
        instance.collectableScore.CrossFadeAlpha(0.0f, 0.0f, false);
        instance.enemiesKilled.CrossFadeAlpha(0.0f, 0.0f, false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyScore = instance.currentEnemiesKilled * 10;
        enemyScoreText.text = enemyScore.ToString();
        if (instance.currentEnemiesKilled == instance.maxEnemiesToKill)
        {
            enemyScore += bonus;
            objectivesCount++;
            enemyScoreText.text = "Enemies Killed Score: " + enemyScore.ToString();
        }

        collectableScore = instance.currentCollectables * 50;
        collectableScoreText.text = collectableScore.ToString();
        if (instance.currentCollectables == instance.maxCollectables)
        {
            collectableScore += bonus;
            objectivesCount++;
            collectableScoreText.text = "Collectables Score: " + collectableScore.ToString();
        }

        objectivesScore = objectivesCount * 1000;
        objectivesScoreText.text = "Objectives Completed Score: " + objectivesScore.ToString();

        finalScore = instance.score + enemyScore + collectableScore;
        finalScoreText.text = "Final Score: " + finalScore.ToString();

    }
}
