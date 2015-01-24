using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Vector2 speed = new Vector2(10, 10);
	
	private Vector2 movement;
	
	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		
		// Collision with enemy
		EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			// Kill the enemy
			EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}
		
		// Damage the player
		if (damagePlayer)
		{
			PlayerHealth playerHealth = this.GetComponent<PlayerHealth>();
			if (playerHealth != null) 
				playerHealth.Damage(1);
		}
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
}