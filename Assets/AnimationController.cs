using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {
    Animator anim;
    GameObject player;
    public bool Jump = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
      //  player = 
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Jump", Jump);
	}
}
