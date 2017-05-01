using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5F;
	public float sensitivityY = 5F;

	public float minimumX = -180F;
	public float maximumX = 180F;

	public float minimumY = -60F;
	public float maximumY = 60F;



	float rotationY = 0F;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rotation();
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
