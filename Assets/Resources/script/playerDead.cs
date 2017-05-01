using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//print (other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
					//print ("hitted");
			PlayerPrefs.SetInt("game over", -1);
		}
	}
}
