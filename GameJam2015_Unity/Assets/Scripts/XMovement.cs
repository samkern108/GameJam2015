using UnityEngine;
using System.Collections;

public class XMovement : MonoBehaviour {

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
		onRails = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (onRails == true) 
		{
			timeLeft -= Time.deltaTime;
			
			if (Input.GetKeyDown (KeyCode.A) && timeLeft <= 0) {
				increment += speed / 100;
				transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.left * 2, increment);
				timeLeft = .5f;
			}
			
			if (Input.GetKeyDown (KeyCode.D) && timeLeft <= 0) {
				increment += speed / 100;
				transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.right * 2, increment);
				timeLeft = .5f;
			
			}
		} 
		else if (onRails == false)
		{			
			if (Input.GetKeyDown (KeyCode.A)) 
			{
				increment += speed / 100;
				transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.left, 0);
			}
			
			if (Input.GetKeyDown (KeyCode.D)) 
			{
				increment += speed / 100;
				transform.position = Vector3.Lerp (transform.position, transform.position + Vector3.right, 0);
			}
		}
		UpdatePosition ();

	}
	//Update the position of the ship based on "Horizontal" input
	void UpdatePosition()
	{
		// Move the player laterally in the 'X' coordinate
		movement.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * increment;
		// Apply the movement vector to the game object's postition
		gameObject.transform.Translate (movement);
		// Trandsform the 3D world position to a screen pixel location
		Vector3 screenPosition = CameraObject.WorldToScreenPoint (
			gameObject.transform.position);
		
		//Off screen to the right?
		if(screenPosition.x > Screen.width)
		{
			// Clamp (reset to the screen's right side
			screenPosition.x = Screen.width;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
		// Off screen to the left
		else if (screenPosition.x < 0)
		{
			// Clamp (reset to the screen's left side
			screenPosition.x = 0;
			// Transform clamped screen position to world space and
			// assign to player ship
			gameObject.transform.position = 
				CameraObject.ScreenToWorldPoint(screenPosition);
		}
	}
}
