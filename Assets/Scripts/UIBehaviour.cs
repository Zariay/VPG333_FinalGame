using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIBehaviour : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void QuitGame()
    {
        SceneManager.UnloadScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

}
