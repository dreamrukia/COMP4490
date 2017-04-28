using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public GameObject wpPrefab;
	public GameObject bulletPrefab;
	List<GameObject> bullet;
    GameObject wp;
    public bool changeWp;
    public Vector3 wpPosition;
    public bool shoot;
    public Camera cam;
    Animator amt;
	public int  timeDelay = 10;
	int currTime = 0;
	Vector3 forwardVec;
	//Rigidbody bulletRb;
	public float velocity;
	// Use this for initialization
	void Start () {
		bullet = new List<GameObject>();
        wp = Instantiate(wpPrefab) as GameObject;
        wp.transform.SetParent(cam.transform);
        wp.transform.localPosition = new Vector3(.16f,-.26f,0.33f);
        wp.transform.localEulerAngles = new Vector3(0,80f,-9.63f);
        //print(wp.transform.parent);
        shoot = false;
        amt = wp.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

		forwardVec = cam.transform.forward;
        if (changeWp)
        {
            
        }
		//print (Input.GetMouseButton (0) + " " + amt.GetBool ("Shoot"));
		if (Input.GetMouseButton(0) && !amt.GetBool("Shoot")) {
			//print ("down");
			amt.SetBool ("Shoot", true);
		}
		if (!Input.GetMouseButton(0) && amt.GetBool("Shoot")) {
			//print ("Up");
			amt.SetBool ("Shoot", false);
		}
		if(Input.GetMouseButton(0)){
			if(currTime == 0){
				shootBullet();
				currTime ++;
			}else{
				currTime = (currTime + 1) % timeDelay;
			}

		}
	}
	private void shootBullet(){
		//print("aaa");
		GameObject bul = Instantiate(bulletPrefab) as GameObject;
		//bul.transform.SetParent(cam.transform);
		bul.transform.position = cam.transform.position + forwardVec.normalized * 5;
		bul.transform.localEulerAngles = new Vector3(0,90f,90f);
		Rigidbody bulletRb = bul.GetComponent<Rigidbody>();
		bulletRb.AddForce((forwardVec + new Vector3(Random.Range(-0.1f,.1f), Random.Range(-.1f,.1f), Random.Range(-.1f,.1f))) * velocity);
		bullet.Add(bul);
	}
}
