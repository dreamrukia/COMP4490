using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public float movementSpeed = 1.0f;
	public float screenScale = 16.0f/9.0f;
	public float speed = 100;
	public float jumpVelocity;
	public float boundDistance;

	public GameObject skybox;
	// Use this for initialization
	void Start () {
		//skybox = GameObject.Find ("Skyball_WithCap");
//		skybox.transform.eulerAngles = Vector3.zero;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
		boundDistance = GetComponent<Collider> ().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
		//print (cam.transform.position);

        movement();
    }

    void movement()
    {

		Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
		Vector3 face = cam.transform.forward;
		Vector3 camUp = cam.transform.up;
		face.y = 0.0f;
		Rigidbody rb = GetComponent<Rigidbody> ();
		skybox.GetComponent<Transform> ().position = cam.GetComponent<Transform>().position;
				
		if (Input.GetKey (KeyCode.W)) {
			rb.velocity += face * speed;

			//rb.AddForce (face * speed);
		} 
		if (Input.GetKey (KeyCode.S)) {
			rb.velocity += -face * speed;
			//rb.AddForce (-face * speed);
		} 
		if (Input.GetKey (KeyCode.A)) {
			Vector3 moveDir = Vector3.Cross (face, camUp).normalized * speed;
			rb.velocity += moveDir;
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector3 moveDir = Vector3.Cross (camUp, face).normalized * speed;
			rb.velocity += moveDir;
		}
		if (Input.GetKeyDown (KeyCode.Space) && Mathf.Abs (rb.velocity.y) <= 0.1) {
			rb.velocity = new Vector3 (0, jumpVelocity, 0);
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			rb.velocity -= face * speed;
			//rb.AddForce (face * speed);
		} 
		if (Input.GetKeyUp (KeyCode.S)) {
			rb.velocity -= -face * speed;
			//rb.AddForce (-face * speed);
		} 
		if (Input.GetKeyUp (KeyCode.A)) {
			Vector3 moveDir = Vector3.Cross (face, camUp).normalized * speed;
			rb.velocity -= moveDir;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			Vector3 moveDir = Vector3.Cross (camUp, face).normalized * speed;
			rb.velocity -= moveDir;
		}

    }

//	bool onGround(){
//		return Physics.Raycast (transform.position, -Vector3.up, boundDistance + 0.3);
//			
//	}

}
