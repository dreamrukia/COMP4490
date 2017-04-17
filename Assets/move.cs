using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public float speed = 1.0f;
	GameObject cam;
	GameObject skybox;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		//print (cam.transform.position);
		if (Input.GetKey(KeyCode.W))
		{
			cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z+speed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z-speed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			cam.transform.position = new Vector3(cam.transform.position.x+speed*16/9, cam.transform.position.y, cam.transform.position.z);
		}
		if (Input.GetKey(KeyCode.A))
		{
			cam.transform.position = new Vector3(cam.transform.position.x-speed*16/9, cam.transform.position.y, cam.transform.position.z);
		}
	}
}
