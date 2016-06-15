using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIBehaviour : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        SceneManager.UnloadScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
    }

}
