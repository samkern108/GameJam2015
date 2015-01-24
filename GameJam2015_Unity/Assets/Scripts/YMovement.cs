using UnityEngine;
using System.Collections;

public class YMovement : MonoBehaviour {

	//Relation to how far the play moves per button press.
	[SerializeField] float increment = 10.0f;
	[SerializeField] float speed = 10.0f;

	// Timer correlating towards player movement
	[SerializeField] float timeLeft = .5f;

	// Determines the screen bounds in relation to the
	// player object. This camera object needs to be populated
	// in the editor (drag and drop the "Main Camera" on to
	// this attribute in the Inpector
	public Camera CameraObject;

	// Helper vector for updating the ship's position
	// Declated here since it is used every update / tick
	// and we do not want to waste CPU power recreating
	// it constantly
	private Vector3 movement = Vector3.zero;

	private bool onRails = false;
	
	// Use this for initialization
	void Start () 
	{
		onRails = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (onRails == true) {
	
						timeLeft -= Time.deltaTime;
		
						if (Input.GetKeyDown (KeyCode.W) && timeLeft <= 0) {
								increment += speed / 100;
								transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.up * 2, increment);
								timeLeft = .5f;
						}
						if (Input.GetKeyDown (KeyCode.S) && timeLeft <= 0) {
								increment += speed / 100;
								transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.down * 2, increment);
								timeLeft = .5f;
						}
						UpdatePosition ();
				} else if (onRails == false) {
						if (Input.GetKeyDown (KeyCode.W)) {
								increment += speed / 100;
								transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.up, 0);
						}
						if (Input.GetKeyDown (KeyCode.S)) {
								increment += speed / 100;
								transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.down, 0);
						}
			UpdatePosition2();
				}

	}
	//Update the position of the ship based on "Horizontal" input
	void UpdatePosition()
	{
		//// Move the player vertia=cally in the 'Y' coordinate
		//movement.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * increment;
		//// Apply the movement vector to the game object's postition
		//gameObject.transform.Translate (movement);
		// Trandsform the 3D world position to a screen pixel location
		Vector3 screenPosition = CameraObject.WorldToScreenPoint (
			gameObject.transform.position);
		
		//Off screen to the right?
		if(screenPosition.y > Screen.height / 2)
		{
			// Clamp (reset to the screen's right side
			screenPosition.y = Screen.height / 2;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
		// Off screen to the left
		else if (screenPosition.y < 0)
		{
			// Clamp (reset to the screen's left side
			screenPosition.y = 40;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
	}

	void UpdatePosition2()
	{
		// Move the player vertia=cally in the 'Y' coordinate
		movement.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * increment;
		// Apply the movement vector to the game object's postition
		gameObject.transform.Translate (movement);
		// Trandsform the 3D world position to a screen pixel location
		Vector3 screenPosition = CameraObject.WorldToScreenPoint (
			gameObject.transform.position);
		
		//Off screen to the right?
		if(screenPosition.y > Screen.height / 2)
		{
			// Clamp (reset to the screen's right side
			screenPosition.y = Screen.height / 2;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
		// Off screen to the left
		else if (screenPosition.y < 0)
		{
			// Clamp (reset to the screen's left side
			screenPosition.y = 40;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
	}
}
