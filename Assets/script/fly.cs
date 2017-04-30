using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour {
    public GameObject flies;
    public float speed = 1000.0f;
    float maxX = 430.0f;
    float minX = 60.0f;
    float maxY = 200.0f;
    float minY = 125.0f;
    float maxZ = 420.0f;
    float minZ = 55.0f;
    Vector3 pos;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = flies.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Random.Range(-speed, speed);
        float y = Random.Range(-speed, speed);
        float z = Random.Range(-speed, speed);
        rb.AddForce(new Vector3(x, y, z));
        pos = rb.transform.position;
        if(pos.x > maxX * 2 || pos.x < minX / 2)
        {
            Destroy(flies);
        }
        if (pos.y > maxY * 2 || pos.y < minY / 2)
        {
            Destroy(flies);
        }
        if (pos.z > maxZ * 2 || pos.z < minZ / 2)
        {
            Destroy(flies);
        }
    }
}
