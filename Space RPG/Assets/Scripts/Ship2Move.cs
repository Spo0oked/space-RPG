using UnityEngine;
using System.Collections;

public class Ship2Move : MonoBehaviour {

	public Rigidbody2D rb; //instance variable of 2d rigid body
	public float speed;

	public float speedFector;
	Vector3 mousePositionInWorld;
	float angle;
	public float startRotationOffset = 90;  //This is angle offset at starting.

	private Animator anim;

	bool pressed;


	void Start () {
		rb = GetComponent<Rigidbody2D> (); //returning the rigid body
		anim = GetComponent<Animator>(); //returning animator
	}
	

	void FixedUpdate () {
		
		float Vinput = Input.GetAxis ("Vertical");
		float boost = speed * 2;
		rb.AddForce (gameObject.transform.up * speed * Vinput); //adding mocement for up/down

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			rb.AddForce (gameObject.transform.up * boost * Vinput); //raising speed for a sprint function
		}
		if (Input.GetKey ("b")) 
		{
			anim.SetBool ("boost", true);
		}
	
		mousePositionInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition); //geting mouse pos
		angle = ( Mathf.Atan2 (mousePositionInWorld.y - transform.position.y, mousePositionInWorld.x - transform.position.x) * Mathf.Rad2Deg); //finding angle to mouse

		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(0, 0, angle+startRotationOffset),speedFector * Time.deltaTime); //rotating ship

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) 
		{ //checking if w or up is pressed and shift is not
			if (Input.GetKey (KeyCode.LeftShift)) 
			{
				anim.SetBool ("boost", true);
				anim.SetBool ("reg", false);
			} 
			else 
			{
				anim.SetBool ("boost", false);
				anim.SetBool ("reg", true);
			}
		} else if (!Input.GetKey (KeyCode.W) || !Input.GetKey (KeyCode.UpArrow)) 
		{
			anim.SetBool ("reg", false);
			anim.SetBool ("boost", false);
		} 
	}
}
