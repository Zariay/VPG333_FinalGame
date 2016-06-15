using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController player;
    public int lives = 3;
    UnityStandardAssets._2D.Camera2DFollow playerCam;
    public static Text livesText;
    public static LevelManager instance;

    public static int maxCollectables = 3;
    public static int currentCollectables;
    public Text collectableScore;

    public static int maxEnemiesToKill;
    public static int currentEnemiesKilled;
    public static Text enemiesKilled;

    public static float maxTime;
    public static float currentTime;
    public static Text timer;

    public static int score;
    public static Text scoreText;

    void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(transform.gameObject);

        player = FindObjectOfType<PlayerController>();
        playerCam = FindObjectOfType<UnityStandardAssets._2D.Camera2DFollow>();
    }

    void Update()
    {
        livesText.text = "Lives: " + lives.ToString();

        enemiesKilled.text = "Enemies: " + currentEnemiesKilled.ToString() + "/" + maxEnemiesToKill.ToString();
        collectableScore.text = "Collectables: " + currentCollectables.ToString() + "/" + maxCollectables.ToString();

        currentTime -= Time.deltaTime;
        timer.text = "Time: " + System.Math.Round(currentTime, 2) + "/" + System.Math.Round(maxTime, 2);

        scoreText.text = "Current Score: " + score.ToString();

        if (lives < 0)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
        }

        if(currentTime <= 0.0f)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
            currentTime = 0.0f;
        }

        if(player.isDead == true)
        {
            playerCam.isFollowing = false;
        }
    }
}
