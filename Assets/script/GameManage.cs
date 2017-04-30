using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {
    Text score;
	int gameOver;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
        score = GameObject.Find("score").GetComponent<Text>();
		PlayerPrefs.SetInt("game over", 0);
	}
	
	// Update is called once per frame
	void Update () {
		gameOver = PlayerPrefs.GetInt("game over");
        if (score.GetComponent<score>().Score <= 0 || gameOver == -1)
        {
			PlayerPrefs.SetInt("highScore", score.GetComponent<score>().highScore);
			PlayerPrefs.SetInt("game over", 0);
            SceneManager.LoadScene("GameOver");
        }

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
    }
	void OnApplicationQuit()
	{
		PlayerPrefs.Save();
	}
}


