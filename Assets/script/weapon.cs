using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public GameObject wpPrefab;
	public float bulletSpreadAngle;
	GameObject wpParticleSys;
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
		wp.transform.localEulerAngles = new Vector3 (0, 80f, -9.63f);
        shoot = false;
        amt = wp.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		wpParticleSys = wp.transform.Find ("Dummy002/WeaponRoot/Particle System").gameObject;

		//print(wpParticleSys.name);
		forwardVec = cam.transform.forward;

        if (changeWp)
        {
            
        }

		//print (Input.GetMouseButton (0) + " " + amt.GetBool ("Shoot"));
		if (Input.GetMouseButton(0) && !amt.GetBool("Shoot")) {
			//print ("down");
			amt.SetBool ("Shoot", true);
			wpParticleSys.SetActive (true);
		}
		if (!Input.GetMouseButton(0) && amt.GetBool("Shoot")) {
			//print ("Up");
			amt.SetBool ("Shoot", false);
			wpParticleSys.SetActive (false);
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
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, forwardVec.normalized, out hit, 10000)) {
			if (hit.collider && hit.collider.gameObject.tag == "Original") {
				hit.collider.gameObject.GetComponent<boxBreak>().broken();
			}
		}


		//bul.transform.SetParent(cam.transform);
		bul.transform.position = cam.transform.position + forwardVec.normalized * 3;
		bul.transform.localEulerAngles = new Vector3(0,90f,90f);
		Rigidbody bulletRb = bul.GetComponent<Rigidbody>();
		bulletRb.AddForce((forwardVec + new Vector3(Random.Range(-bulletSpreadAngle,bulletSpreadAngle), Random.Range(-bulletSpreadAngle,bulletSpreadAngle), 
			Random.Range(-bulletSpreadAngle,bulletSpreadAngle))) * velocity);
		bullet.Add(bul);

	}
}
