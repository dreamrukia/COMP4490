using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {
	List<Rigidbody> fragments;

	// Use this for initialization
	void Start () {
		fragments = new List<Rigidbody> ();
		Rigidbody[] temp = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody ha in temp) {
			print (ha.tag);
			if (ha.tag != "Original") {
				fragments.Add (ha);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//print (other.gameObject.tag);
		if (other.gameObject.tag == "bullet") {
			//print ("hitted");
			broken ();
		}
	}

	void broken(){
		foreach (Rigidbody rb in fragments) {
			rb.isKinematic = false;
		}
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		mr.enabled = false;
	}
}
