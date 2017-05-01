using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyGenerator : MonoBehaviour {
    public GameObject flyPerfab;
    public float minGenTime = 1.0f;
    public float maxGenTime = 5.0f;
    float wait = 0;
	// Use this for initialization
	void Start () {
        wait = Random.Range(minGenTime*60,maxGenTime*60);
	}
	
	// Update is called once per frame
	void Update () {
        //print(wait);
        if (wait <= 0)
        {
            wait = Random.Range(minGenTime * 60, maxGenTime * 60);
            createFly();
        }
        else
            wait--;
	}

    void createFly()
    {
        GameObject fly = Instantiate(flyPerfab) as GameObject;
        fly.transform.position = transform.position;
    }
}
