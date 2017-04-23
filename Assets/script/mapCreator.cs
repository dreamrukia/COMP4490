using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreator : MonoBehaviour {

	public int blocksOfX = 10;
	public int blocksOfY = 10;
	GameObject[,] blockArr;

	// Use this for initialization
	void Start () {
		blockArr = new GameObject[blocksOfX , blocksOfY];
		for(int i = 0; i < blocksOfX; i++){
			for(int j = 0; j < blocksOfY; j++){

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
