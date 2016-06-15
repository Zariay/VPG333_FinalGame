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

    Objectives objectives;

    // Use this for initialization
    void Start()
    {
        objectives = FindObjectOfType<Objectives>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyScore = objectives.currentEnemiesKilled * 10;
        enemyScoreText.text = enemyScore.ToString();
        if (objectives.currentEnemiesKilled == objectives.maxEnemiesToKill)
        {
            enemyScore += bonus;
            objectivesCount++;
            enemyScoreText.text = enemyScore.ToString();
        }
        
        collectableScore = objectives.currentCollectables * 50;
        collectableScoreText.text = collectableScore.ToString();
        if (objectives.currentCollectables == objectives.maxCollectables)
        {
            collectableScore += bonus;
            objectivesCount++;
            collectableScoreText.text = collectableScore.ToString();
        }

        objectivesScore = objectivesCount * 1000;
        objectivesScoreText.text = objectivesScore.ToString(); 

        finalScore = objectives.score + enemyScore + collectableScore;
        finalScoreText.text = finalScore.ToString();
    }
}
