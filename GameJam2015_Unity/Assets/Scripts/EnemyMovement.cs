using UnityEngine;
using System.Collections;

//Made by Thomas

public class EnemyMovement : MonoBehaviour {

	public Vector2 direction;
	public float speed;
	
	Vector2 movementDirection;

	// Use this for initialization
	void Start () {
		movementDirection = new Vector2(direction.x * speed, direction.y * speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(movementDirection);
	}
}
