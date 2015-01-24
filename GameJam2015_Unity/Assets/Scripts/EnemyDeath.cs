using UnityEngine;
using System.Collections;

//Made by Thomas

public class EnemyDeath : MonoBehaviour {

	public int hp = 1;

	void OnEnable(){
		hp = 1;
		Invoke("Destroy", 2f);
	}
	
	
	void Destroy(){
		gameObject.SetActive(false);
	}
	
	void OnDisable(){
		CancelInvoke();
	}
}
