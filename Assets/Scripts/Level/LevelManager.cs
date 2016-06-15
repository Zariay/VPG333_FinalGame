using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController player;
    public int lives = 3;
    PlayerHealth pHealth;
    UnityStandardAssets._2D.Camera2DFollow playerCam;
    Objectives objectives;
    public Text livesText;
    public static LevelManager instance;

    public int maxCollectables = 3;
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

    public Slider playerHealth;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        pHealth = player.GetComponent<PlayerHealth>();
        playerCam = FindObjectOfType<UnityStandardAssets._2D.Camera2DFollow>();
        objectives = FindObjectOfType<Objectives>();

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (lives < 0)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
        }

        if(objectives.currentTime <= 0.0f)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
            objectives.currentTime = 0.0f;
        }

        if(player.isDead == true)
        {
            playerCam.isFollowing = false;
        }

        playerHealth.value = pHealth.currentHealth;
        livesText.text = "Lives: " + lives.ToString();

        enemiesKilled.text = currentEnemiesKilled.ToString() + "/" + maxEnemiesToKill.ToString();
        collectableScore.text = currentCollectables.ToString() + "/" + maxCollectables.ToString();

        currentTime -= Time.deltaTime;
        timer.text = System.Math.Round(currentTime, 2) + "/" + System.Math.Round(maxTime, 2);

        scoreText.text = score.ToString();
    }

}
