using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManage : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Text>();
        score.text += PlayerPrefs.GetInt("highScore");
        PlayerPrefs.DeleteKey("highScore");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("mainScene2");
        }
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
    }
}
