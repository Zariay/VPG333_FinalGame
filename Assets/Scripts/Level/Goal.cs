using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
    

    void OnTriggerEnter2D(Collider2D other)
    {
        Application.LoadLevel(Application.loadedLevel+1);
       
    }
}
