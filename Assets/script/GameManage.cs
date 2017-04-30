using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (score.GetComponent<score>().Score <= 0)
        {
            PlayerPrefs.SetInt("score", score.GetComponent<score>().Score);
            SceneManager.LoadScene("GameOver");
        }
    }
}
