using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {



	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public float follow;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;
			
			Vector3 targetDirection = (target.transform.position - posNoZ);
			
			interpVelocity = targetDirection.magnitude * follow;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 
			
			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);
		


		}

	}
	void Update () {
		//transform.position.x = Input.mousePosition.x;
		//transform.position.z = Input.mousePosition.y; 
		// error CS1612: Cannot modify a value type return value of `UnityEngine.Transform.position'. 
		// Consider storing the value in a temporary variable
		
		//Vector3 thePos = new Vector3( Input.mousePosition.x, transform.position.y, Input.mousePosition.y ); // temporary variable
		//transform.position = thePos;
	} 
	}

