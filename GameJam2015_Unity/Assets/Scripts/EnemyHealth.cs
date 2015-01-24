using UnityEngine;

/// <summary>
/// Made with help from PixelNest's Unity 2D tutorials
/// </summary>
public class EnemyHealth : MonoBehaviour
{
	public int hp = 1;
	
	int hitPoints;
	
	void Start(){
		gameObject.SetActive(false);
	}
	
	void OnEnable(){
		hitPoints = hp;
	}
	
	
	public void Damage(int damageCount)
	{
		hitPoints -= damageCount;
		
		if (hitPoints <= 0)
		{
			Invoke("Destroy", .01f);
		}
	}
	
	void Destroy(){
		gameObject.SetActive(false);
	}
	
	void OnDisable(){
		CancelInvoke();
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