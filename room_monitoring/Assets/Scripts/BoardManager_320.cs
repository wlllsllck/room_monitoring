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
	public GameObject table;
	public GameObject Mac;
	public GameObject garden;
	public GameObject treasure;
//	public GameObject Bin;
//	//	public GameObject Teatable;
//	public GameObject Refrigerator;
//	public GameObject[] TableTiles;
//	public GameObject[] SinkTiles;
//	//	public GameObject[] SofaTiles;
//	public GameObject Booksh;
//	//	public GameObject[] PrinterTiles;
	public GameObject[] TreeTiles;

	private Transform boardHolder;

	void BoardSetup(){

		// main room floor
		for (int x = 0; x <= 20; x++) {
			for (int y = 0; y <= 10; y++) {
				GameObject toInstantiate = floorTiles[0];
				Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
			}
		}

		//wall
		for (int x = 1; x < 20; x++) {
			if (x != 12 && x != 13 && x != 14 && x != 15) {
				for (int y = -1; y <=1; y++) {
					if (y == -1) {
						Instantiate (wallTiles[0], new Vector3 ((float)(startx + x)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
					}
					else if (y == 0) {
						Instantiate (wallTiles[1], new Vector3 ((float)(startx + x)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
					} 
					else if (y == 1) {
						Instantiate (wallTiles[2], new Vector3 ((float)(startx + x)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
					}
				}
			}
		}

		int count = 3;
		for (int y = -1; y <= 10; y++) {
			if (count == 3) {
				Instantiate (wallTiles[3], new Vector3 ((float)(startx)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count--;
			} 
			else if (count == 2) {
				Instantiate (wallTiles[4], new Vector3 ((float)(startx)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count--;
			} 
			else if (count == 1) {
				Instantiate (wallTiles[5], new Vector3 ((float)(startx)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count = 3;
			}
		}

		count = 3;
		for (int y = -1; y <= 10; y++) {
			if (count == 3) {
				Instantiate (wallTiles[3], new Vector3 ((float)(startx + 20)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count--;
			} 
			else if (count == 2) {
				Instantiate (wallTiles[4], new Vector3 ((float)(startx + 20)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count--;
			} 
			else if (count == 1) {
				Instantiate (wallTiles[5], new Vector3 ((float)(startx + 20)*0.64f, (float)(starty - y)*0.64f, 0f), Quaternion.identity);
				count = 3;
			}
		}

		//table
		Instantiate (table, new Vector3 ((float)(startx + 12.5)*0.64f, (float)(starty - 8.5)*0.64f, 0f), Quaternion.identity);

		//mac
		Instantiate (Mac, new Vector3 ((float)(startx + 14.5)*0.64f, (float)(starty - 7.75)*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)(startx + 11)*0.64f, (float)(starty - 7.75)*0.64f, 0f), Quaternion.identity);

		//room number
		Instantiate (numberTiles[0], new Vector3 ((float)(startx + 4)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);
		Instantiate (numberTiles[1], new Vector3 ((float)(startx + 5)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);
		Instantiate (numberTiles[2], new Vector3 ((float)(startx + 6)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);

		//garden 
		Instantiate (garden, new Vector3 ((float)(startx + 2)*0.64f, (float)(starty - 5.5)*0.64f, 0f), Quaternion.identity);

		//tree 
		Instantiate (TreeTiles[0], new Vector3 ((float)(startx + 18)*0.64f, (float)(starty - 2)*0.64f, 0f), Quaternion.identity);

		//treasure
		Instantiate (treasure, new Vector3 ((float)(startx + 18)*0.64f, (float)(starty - 9)*0.64f, 0f), Quaternion.identity);

	}

	public void SetupScene()
	{
		BoardSetup ();
	}

}
