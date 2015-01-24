using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// THIS IS AN AMAZINGLY BAD SCRIPT THAT WORKS BY THE POWER OF SHEER LAZINESS
/// </summary>
public class BackgroundScroll : MonoBehaviour
{
	
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	
	private Transform backgroundPart;
	
	// 3 - Get all the children
	void Start()
	{
		backgroundPart = transform.GetChild(0);
	}
	
	void Update()
	{
		// Movement
		Vector3 movement = new Vector3(
			speed.x * direction.x,
			speed.y * direction.y,
			0);
		
		movement *= Time.deltaTime;
		transform.Translate(movement);
		
		if(backgroundPart.position.x+backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.x/3 < Camera.main.pixelRect.x)
		{
			backgroundPart.position = new Vector3(backgroundPart.position.x+backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.x,backgroundPart.position.y, backgroundPart.position.z);
		}
		if(backgroundPart.position.x-backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.x/3 > Camera.main.pixelRect.x)
		{
			backgroundPart.position = new Vector3(backgroundPart.position.x-backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.x,backgroundPart.position.y, backgroundPart.position.z);
		}
		
		if(backgroundPart.position.y+backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.y/3 < Camera.main.pixelRect.y)
		{
			backgroundPart.position = new Vector3(backgroundPart.position.x,backgroundPart.position.y+backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.y, backgroundPart.position.z);
		}
		if(backgroundPart.position.y-backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.y/3 > Camera.main.pixelRect.y)
		{
			backgroundPart.position = new Vector3(backgroundPart.position.x,backgroundPart.position.y-backgroundPart.GetComponent<SpriteRenderer>().sprite.bounds.size.y, backgroundPart.position.z);
		}
	}
}