using UnityEngine;
using System.Collections;

public class UIBehaviour : MonoBehaviour {
    public void LoadLevel()
    {
        Application.LoadLevel(Application.loadedLevel+1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Application.LoadLevel("FirstLevelFIXED");
    }
   
}
