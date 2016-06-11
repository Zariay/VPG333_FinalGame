using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Objectives : MonoBehaviour
{
    public int maxCollectables;
    public int currentCollectables;
    public Text collectableScore;

    public int maxEnemiesToKill;
    public int currentEnemiesKilled;
    public Text enemiesKilled;

    public float maxTime;
    public float currentTime;
    public Text timer;

    public int score;
    public Text scoreText;

    void Update()
    {
        enemiesKilled.text = currentEnemiesKilled + "/" + maxEnemiesToKill;
        collectableScore.text = currentCollectables + "/" + maxCollectables;

        currentTime -= Time.deltaTime;
        timer.text = System.Math.Round(currentTime, 2) + "/" + System.Math.Round(maxTime,2);
    }
}
