using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxBreak : MonoBehaviour {
	List<Rigidbody> fragments;

	// Use this for initialization
	void Start () {
		fragments = new List<Rigidbody> ();
		Rigidbody[] temp = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody ha in temp) {
			//print (ha.tag);
			if (ha.tag != "Original") {
				fragments.Add (ha);
				ha.gameObject.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//print (other.gameObject.tag);
//		if (other.gameObject.tag == "bullet") {
//			//print ("hitted");
//			broken ();
//		}
	}

	public void broken(){
		foreach (Rigidbody rb in fragments) {
			print (rb);
			rb.gameObject.SetActive (true);
			rb.isKinematic = false;
		}
		MeshRenderer[] mr = GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer m in mr) {
			if (m.tag == "Original") {
				m.enabled = false;
			}
		}

	}
}
