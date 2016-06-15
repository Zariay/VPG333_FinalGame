using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController player;
    PlayerHealth pHealth;
    UnityStandardAssets._2D.Camera2DFollow playerCam;
    Objectives objectives;

    public Slider playerHealth;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        pHealth = player.GetComponent<PlayerHealth>();
        playerCam = FindObjectOfType<UnityStandardAssets._2D.Camera2DFollow>();
        objectives = FindObjectOfType<Objectives>();
    }

    void Update()
    {
        if (player.lives < 0)
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

        playerHealth.value = pHealth.currentHealth;
    }

}
