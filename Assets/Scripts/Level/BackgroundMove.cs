using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour {

	 public float movementSpeed = 10;

     void Update()
     {
         transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
     }
}
