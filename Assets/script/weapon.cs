using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public GameObject wpPrefab;
	GameObject wpParticleSys;
    GameObject wp;
    public bool changeWp;
    public Vector3 wpPosition;
    public bool shoot;
    public Camera cam;
    Animator amt;
	// Use this for initialization
	void Start () {
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

		print(wpParticleSys.name);
        if (changeWp)
        {
            
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            amt.SetBool("Shoot", true);
			wpParticleSys.SetActive (true);
        }
		if (Input.GetMouseButtonUp(0))
        {
            amt.SetBool("Shoot", false);
			wpParticleSys.SetActive (false);
            //shoot = false;
        }
	}
}
