using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	public float movementSpeed = 1.0f;
	public float screenScale = 16.0f/9.0f;

	GameObject skybox;
	// Use this for initialization
	void Start () {
		skybox = GameObject.Find ("Skyball_WithCap");
//		skybox.transform.eulerAngles = Vector3.zero;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
		//print (cam.transform.position);

        movement();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + movementSpeed );
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z - movementSpeed );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + movementSpeed * screenScale, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * screenScale, transform.position.y, transform.position.z );
        }
    }


}
