using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager_320 : MonoBehaviour {

	int startx = -1; // for x start 26 and end with 32
	int starty = -6; // for y start -1 and end with 18

	public GameObject[] wallTiles;
	public GameObject[] floorTiles;
	public GameObject[] numberTiles;
//	public GameObject Window;
//	public GameObject Monitor;
//	public GameObject Cupset;
//	public GameObject CT_Maker;
//	public GameObject Chair;
//	public GameObject[] tableComponent;
//
//
//	public GameObject Mac;
//	public GameObject Bin;
//	//	public GameObject Teatable;
//	public GameObject Refrigerator;
//	public GameObject[] TableTiles;
//	public GameObject[] SinkTiles;
//	//	public GameObject[] SofaTiles;
//	public GameObject Booksh;
//	//	public GameObject[] PrinterTiles;
//	public GameObject[] TreeTiles;

	private Transform boardHolder;

	void BoardSetup(){
		// main room floor

		for (int x = 0; x <= 18; x++) {
			for (int y = 0; y <= 12; y++) {
				GameObject toInstantiate = floorTiles[0];
				Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
			}
		}
	}

	public void SetupScene()
	{
		BoardSetup ();
	}

}
