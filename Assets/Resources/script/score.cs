using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public int Score;
	public int highScore;
	Text text;
	// Use this for initialization
	void Start () {
		Score = 1000;
		highScore = Score;
		changeScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void incrScore(){
		Score += 100;
		highScore = Mathf.Max (highScore, Score);
		print (highScore);
		changeScore ();
	}

	public void decrScore(){
		Score -= 200;
		highScore = Mathf.Max (highScore, Score);
		print (highScore);
		changeScore ();
	}

	void changeScore(){
		text = GetComponent<Text> ();
		text.text = "Score: " + Score;
	}
}
