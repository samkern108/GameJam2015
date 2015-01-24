using UnityEngine;

/// <summary>
/// Thanks, Pixelnest, for the awesome Unity 2D tutorial!
/// </summary>
public class PlayerProjectile : MonoBehaviour
{
	public int damage = 1;
	
	void Start()
	{
	//if you have time, change it so that when the bullet leaves the screen it vanishes
		Destroy(gameObject, 2);
	}
}