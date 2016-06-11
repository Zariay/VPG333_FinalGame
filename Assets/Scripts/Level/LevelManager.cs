using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController player;
    PlayerHealth pHealth;
    UnityStandardAssets._2D.Camera2DFollow playerCam;

    public Slider playerHealth;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        pHealth = player.GetComponent<PlayerHealth>();
        playerCam = GameObject.FindObjectOfType<UnityStandardAssets._2D.Camera2DFollow>();

    }

    void Update()
    {
        if (player.lives < 0)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
        }

        playerHealth.value = pHealth.currentHealth;
    }

}
