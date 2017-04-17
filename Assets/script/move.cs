using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -180F;
    public float maximumX = 180F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public float movementSpeed = 1.0f;
    public float screenScale = 16.0f/9.0f;

    float rotationY = 0F;

	GameObject cam;
	GameObject skybox;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Camera");
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
		//print (cam.transform.position);
        rotation();
        movement();
    }

    float getMoveIntensityY()
    {
        return transform.rotation.y / maximumX;
    }

    float getMoveIntensityX()
    {
        return transform.rotation.x / maximumY;
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + movementSpeed, cam.transform.position.y, cam.transform.position.z + movementSpeed * getMoveIntensityY());
        }
        if (Input.GetKey(KeyCode.S))
        {
            cam.transform.position = new Vector3(cam.transform.position.x - movementSpeed, cam.transform.position.y, cam.transform.position.z - movementSpeed * getMoveIntensityY());
        }
        if (Input.GetKey(KeyCode.D))
        {
            cam.transform.position = new Vector3(cam.transform.position.x + movementSpeed * screenScale, cam.transform.position.y, cam.transform.position.z + movementSpeed * screenScale * getMoveIntensityY());
        }
        if (Input.GetKey(KeyCode.A))
        {
            cam.transform.position = new Vector3(cam.transform.position.x - movementSpeed * screenScale, cam.transform.position.y, cam.transform.position.z - movementSpeed * screenScale * getMoveIntensityY());
        }
    }

    void rotation()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }
}
