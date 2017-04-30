using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public float movementSpeed = 1.0f;
	public float screenScale = 16.0f/9.0f;
	public float speed = 100;
	public float jumpVelocity;
	public float boundDistance;

	// Use this for initialization
	void Start () {
		//skybox = GameObject.Find ("Skyball_WithCap");
//		skybox.transform.eulerAngles = Vector3.zero;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
		boundDistance = GetComponent<Collider> ().bounds.extents.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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
        //print(canMove(face));
		if (Input.GetKey (KeyCode.W) && canMove(face)) {
			rb.position += face * speed;

			//rb.AddForce (face * speed);
		} 
		if (Input.GetKey (KeyCode.S) && canMove(-face)) {
			rb.position += -face * speed;
			//rb.AddForce (-face * speed);
		} 
		if (Input.GetKey (KeyCode.A)) {
			Vector3 moveDir = Vector3.Cross (face, camUp).normalized * speed;
            if (canMove(moveDir))
            {
                rb.position += moveDir;
            }
		}
		if (Input.GetKey (KeyCode.D) && canMove(face)) {
			Vector3 moveDir = Vector3.Cross (camUp, face).normalized * speed;
            if (canMove(moveDir))
            {
                rb.position += moveDir;
            }
        }
        //print(onGround());
		if (Input.GetKeyDown (KeyCode.Space) && onGround()) {
			rb.velocity = new Vector3 (0, jumpVelocity, 0);
		}
        //if (onGround())
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        //}

    }

    bool canMove(Vector3 direction)
    {
        return !(Physics.Raycast(transform.position+new Vector3(0,5,0), direction.normalized, speed + 10f));
    }
	bool onGround(){
		return Physics.Raycast (transform.position, -Vector3.up, boundDistance + 0.3f);
	}

}
