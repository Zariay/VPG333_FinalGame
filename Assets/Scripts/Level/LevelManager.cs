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
    }

}
