using UnityEngine;
using System.Collections;

public class Surprise : MonoBehaviour
{

    public GameObject appear;
   
    public bool isOff = true;


    void Awake()
    {
        appear.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isOff = false;
    }


    void Update()
    {
        if (isOff == false)
        {
            appear.SetActive(true);
            Debug.Log(isOff);
        }

    }



}
