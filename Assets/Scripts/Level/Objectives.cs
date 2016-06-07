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

    void Update()
    {
        enemiesKilled.text = currentEnemiesKilled + "/" + maxEnemiesToKill;
        collectableScore.text = currentCollectables + "/" + maxCollectables;
    }
}
