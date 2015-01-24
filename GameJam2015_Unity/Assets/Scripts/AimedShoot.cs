using UnityEngine;
using System.Collections;

public class AimedShoot : MonoBehaviour {

	public float projectile_speed = 10;
	public GameObject projectile;
	public float amount = 500;
	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{	
			GameObject p = Instantiate(projectile, transform.position, transform.rotation) as GameObject;	
			
			Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 dir = (Input.mousePosition - sp).normalized;
			p.rigidbody2D.AddForce(dir * amount);	
			
			var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			p.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}