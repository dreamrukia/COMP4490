using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class increaseScore : MonoBehaviour {
	public Text ScoreScript;
	// Use this for initialization
	void Start () {
		ScoreScript = GameObject.Find ("score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateScore(){
		ScoreScript.GetComponent<score> ().incrScore ();
	}
}
