using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManage : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Text>();
        score.text += PlayerPrefs.GetInt("Score");
        PlayerPrefs.DeleteKey("Score");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("mainScene2");
        }
    }
}
