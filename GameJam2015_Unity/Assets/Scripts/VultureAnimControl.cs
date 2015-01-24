using UnityEngine;
using System.Collections;

public class VultureAnimControl : MonoBehaviour {

	Animator anim;
	
	int animPath = 1;
	//bool isMoving = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		//anim.SetBool ("isMoving", isMoving);
		anim.SetInteger ("animPath", animPath);
	}
	
}
