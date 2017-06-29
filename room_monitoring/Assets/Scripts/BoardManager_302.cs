using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager_302 : MonoBehaviour {

//	public int rows = 16;
//	public int columns = 24;
	int startx = 26; // for x start 26 and end with 32
	int starty = -1; // for y start -1 and end with 18

	public GameObject[] wallTiles;
	public GameObject[] floorTiles;
	public GameObject[] numberTiles;
	public GameObject Window;
//	public GameObject Mac;
//	public GameObject Bin;
//	public GameObject Teatable;
//	public GameObject Refrigerator;
//	public GameObject[] TableTiles;
//	public GameObject[] SinkTiles;
//	public GameObject[] SofaTiles;
//	public GameObject Booksh;
//	public GameObject[] PrinterTiles;
//	public GameObject[] TreeTiles;

	private Transform boardHolder;

	// for room 302

	void BoardSetup()
	{
//		double x;
//		double y;

		// main room floor

		for (int x = 0; x <= 24; x++) {
			for (int y = 0; y <= 16; y++) {
				GameObject toInstantiate = floorTiles[0];
				Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
			}
		}

		// front wall

		for (int x = 0; x <= 24; x++) {
			for (int y = -1; y <= 1; y++) {
				GameObject toInstantiate;
				if ((x != 6) && (x != 7) && (x != 8)) {
					if (y == -1) {
						toInstantiate = wallTiles[2];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}

					else if (y == 0) {
						toInstantiate = wallTiles[1];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}

					else if (y == 1) {
						toInstantiate = wallTiles[0];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}
				}
			}
		}

		// room number 
		Instantiate (numberTiles[3], new Vector3 ((float)(startx + 10)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);
		Instantiate (numberTiles[0], new Vector3 ((float)(startx + 11)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);
		Instantiate (numberTiles[2], new Vector3 ((float)(startx + 12)*0.64f, (float)(starty)*0.64f, 0f), Quaternion.identity);

		// window side wall

		for (int x = 0; x <= 22; x++) {
			for (int y = 17; y <= 19; y++) {
				GameObject toInstantiate;
					if (y == 17) {
						toInstantiate = wallTiles[2];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}

					else if (y == 18) {
						toInstantiate = wallTiles[1];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}

					else if (y == 19) {
						toInstantiate = wallTiles[0];
						Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
					}
			}
		}

		// right side wall

		for (int x = 23; x <= 24; x++) {
			for (int y = 2; y <= 19; y++) {
				GameObject toInstantiate = wallTiles[3];
				Instantiate (toInstantiate, new Vector3 ((float)(startx + x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
			}
		}

		// window 

		Instantiate (Window, new Vector3 ((float)(startx + 2)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 4)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 6)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 8)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);

		Instantiate (Window, new Vector3 ((float)(startx + 13)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 15)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 17)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);
		Instantiate (Window, new Vector3 ((float)(startx + 19)*0.64f, (float)(starty + 18)*0.64f, 0f), Quaternion.identity);


		// walk way in building
		Instantiate (floorTiles[1], new Vector3 ((float)(startx + 6)*0.64f, (float)(starty - 1)*0.64f, 0f), Quaternion.identity);
		Instantiate (floorTiles[1], new Vector3 ((float)(startx + 7)*0.64f, (float)(starty - 1)*0.64f, 0f), Quaternion.identity);
		Instantiate (floorTiles[1], new Vector3 ((float)(startx + 8)*0.64f, (float)(starty - 1)*0.64f, 0f), Quaternion.identity);

		for (int x = -1; x <= 50; x++) {
			for (int y = -2; y >= -4; y--) {
				GameObject toInstantiate = floorTiles[1];
				Instantiate (toInstantiate, new Vector3 ((float)(x)*0.64f, (float)(starty + y)*0.64f, 0f), Quaternion.identity);
			}
		}

	}

	public void SetupScene()
	{
		BoardSetup ();
	}


}
