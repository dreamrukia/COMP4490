using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	void Start(){

	}

	void Awake(){
		Destroy(gameObject, 5);
	}
	void OnCollisionEnter(Collision collisionInfo){
		if(collisionInfo.transform.CompareTag("Ground")){
			Destroy(gameObject);
		}
	}


}
