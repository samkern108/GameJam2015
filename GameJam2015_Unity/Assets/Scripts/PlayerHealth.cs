using UnityEngine;

/// <summary>
/// Thanks PixelNest for helping us out with this one!
/// </summary>
public class PlayerHealth : MonoBehaviour
{
	public int hp = 5;

	public void Damage(int damageCount)
	{
		Debug.Log ("OW Player got hit.");
		hp -= damageCount;
		
		if (hp <= 0)
		{
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
	/*	// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}*/
	}
}