using UnityEngine;

/// <summary>
/// Made with help from PixelNest's Unity 2D tutorials
/// </summary>
public class EnemyHealth : MonoBehaviour
{
	public int hp = 1;
	
	
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		PlayerProjectile shot = otherCollider.gameObject.GetComponent<PlayerProjectile>();
		if (shot != null)
		{
			Damage(shot.damage);
				
			// Destroy the shot
			Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
		}
	}
}