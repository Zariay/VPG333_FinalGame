using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    PlayerController player;
    UnityStandardAssets._2D.Camera2DFollow playerCam;
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        playerCam = GameObject.FindObjectOfType<UnityStandardAssets._2D.Camera2DFollow>();
    }

    void Update()
    {
        if (player.lives < 0)
        {
            player.enabled = false;
            playerCam.isFollowing = false;
        } 
    }

}
