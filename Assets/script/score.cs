using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public int Score;
	Text text;
	// Use this for initialization
	void Start () {
		Score = 1000;
		changeScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void incrScore(){
		Score += 100;
		changeScore ();
	}

	public void decrScore(){
		Score -= 200;
		changeScore ();
	}

	void changeScore(){
		text = GetComponent<Text> ();
		text.text = "Score: " + Score;
	}
}
