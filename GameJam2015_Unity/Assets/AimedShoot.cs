using UnityEngine;
using System.Collections;

public class AimedShoot : MonoBehaviour {

	public float projectile_speed = 10;
	public GameObject projectile;
	public float amount = 10;
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			/*Debug.Log("Pressed left click.");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
			{
				GameObject p = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			}*/
			
			Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 dir = (Input.mousePosition - sp).normalized;
			rigidbody2D.AddForce (dir * amount);
		}
			
	}
	
}
