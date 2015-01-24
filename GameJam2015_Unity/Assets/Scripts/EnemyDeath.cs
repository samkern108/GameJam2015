using UnityEngine;
using System.Collections;

//Made by Thomas

public class EnemyDeath : MonoBehaviour {

	void OnEnable(){
		Invoke("Destroy", 2f);
	}
	
	
	void Destroy(){
		gameObject.SetActive(false);
	}
	
	void OnDisable(){
		CancelInvoke();
	}
}
