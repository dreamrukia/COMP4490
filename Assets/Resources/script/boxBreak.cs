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
			if (ha.tag != "Original" && ha.tag != "fly") {
				fragments.Add (ha);
				ha.gameObject.SetActive (false);
				ha.gameObject.GetComponent<Collider> ().enabled = false;
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
			//print (rb);
			rb.gameObject.SetActive (true);
			rb.gameObject.GetComponent<Collider> ().enabled = true;
			rb.isKinematic = false;
		}
		MeshRenderer[] mr = GetComponentsInChildren<MeshRenderer> ();
		foreach (MeshRenderer m in mr) {
			if (m.tag == "Original") {
				m.enabled = false;
				gameObject.GetComponent<Collider> ().enabled = false;
				gameObject.GetComponent<decreaseScore> ().updateScore ();
			}else if (m.tag == "fly") {
				m.enabled = false;
				gameObject.GetComponent<Collider> ().enabled = false;
				gameObject.GetComponent<increaseScore> ().updateScore ();
			}
		}



	}
}
