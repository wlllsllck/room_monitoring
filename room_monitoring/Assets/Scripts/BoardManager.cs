using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public int rows = 16;
	public int columns = 24;

	public GameObject[] wallTiles;
	public GameObject[] floorTiles;
	public GameObject[] numberTiles;
	public GameObject Window;
	public GameObject Mac;
	public GameObject Bin;
	public GameObject Teatable;
	public GameObject Refrigerator;
	public GameObject[] TableTiles;
	public GameObject[] SinkTiles;
	public GameObject[] SofaTiles;
	public GameObject Booksh;
	public GameObject[] PrinterTiles;
	public GameObject[] TreeTiles;

	private Transform boardHolder;

	// for room 303

	void BoardSetup()
	{
		//boardHolder = new GameObject ("Board").transform;
		//Instantiate (Mac, new Vector3 (0, 0, 0f), Quaternion.identity);
		//Instantiate (Window, new Vector3 (1, 1, 0f), Quaternion.identity);
		double x;	//26 -> columns
		double y;	// rows
		int count = 0;
		for (x = -1.0; x <=columns+1; x++ ) {
			count++;
			for (y = -2.0; y <=rows+2; y++ ) {
				GameObject toInstantiate = floorTiles[5];
				if (x > -2 && x < 19 && y <= 0) {
						//toInstantiate = wallTiles [2];
					//if (x == 1) {
					//	toInstantiate = wallTiles [4];
					//}
					if (y == -2.0) {
						toInstantiate = wallTiles [3];
					} 
					else if (y == -1.0) {
						toInstantiate = wallTiles [1];
					} 
					else if (y == 0.0) {
						toInstantiate = wallTiles [0];
					}
				}

				if (x == columns || x == columns +1 ) {
					if( y > 0)
						toInstantiate = wallTiles [4];
					else if (y == -2.0) {
						toInstantiate = wallTiles [3];
					} 
					else if (y == -1.0) {
						toInstantiate = wallTiles [1];
					} 
					else if (y == 0.0) {
						toInstantiate = wallTiles [0];
					}
				}

				if (x == -1 || x == 0) {
					if( y > 0)
						toInstantiate = wallTiles [4];
				}

				if (y == 0.0) {
					if ((count == 23) || (count == 24) || (count == 25))
						toInstantiate = floorTiles [5];
				}

				if (y == -1.0) {
					if ((count == 17) || (count == 19))
						toInstantiate = numberTiles [3];
					else if (count == 18)
						toInstantiate = numberTiles [0];
				}

				if (y == -2.0) {
					if ((count == 23) || (count == 24) || (count == 25))
						toInstantiate = floorTiles [3];
				}

				if (y == rows) {
					if(( x > 0) && ( x < columns)){
						toInstantiate = wallTiles[3];
					}
				}

				if (y == rows + 2) {
					if(( x > 0) && ( x < columns)){
						toInstantiate = wallTiles[0];
					}
				}
				if (y == rows + 1) {
					if (count == 5 || count == 7 || count == 9 || count == 11)
						//toInstantiate = wallTiles [2];
						//Instantiate (toInstantiate, new Vector3 ((float)x*0.64f, (float)y*0.64f, 0f), Quaternion.identity);
						toInstantiate = Window;
					else if (count == 15 || count == 17 || count == 19 || count == 21)
						//toInstantiate = wallTiles [2];
						//Instantiate (toInstantiate, new Vector3 ((float)x*0.64f, (float)y*0.64f, 0f), Quaternion.identity);
						toInstantiate = Window;
					else 
						if(( x > 0) && ( x < columns)){
							toInstantiate = wallTiles[1];
						}
						
				}


				Instantiate (toInstantiate, new Vector3 ((float)x*0.64f, (float)y*0.64f, 0f), Quaternion.identity);
				//instance.transform.SetParent (boardHolder);
			}
		}

		// boarder table

		GameObject _toInstantiate;
		int startx = 5;
		int starty = 15;
		for (int l = 0; l < 2; l++) {
			for (int k = 0; k < 4; k++) {
				for (int i = 0; i < 3; i++) {
					for (int j = 1; j <= 3; j++) {
						int temp = (i*3 + j) - 1;			//1, 2, 3, ... , 9	
						int xx = startx + (j-1);
						int yy = starty - i;
						_toInstantiate = TableTiles[temp];
						Instantiate (_toInstantiate, new Vector3 ((float)xx*0.64f, (float)yy*0.64f, 0f), Quaternion.identity);
					}
				}
				starty -= 2;
			}
			starty = 15;
			startx += 16;
		}

		// center table


		GameObject __toInstantiate;
		int startxx = 11;
		int startyy = 15;
		for (int l = 0; l < 2; l++) {
			for (int k = 0; k < 4; k++) {
				for (int i = 0; i < 3; i++) {
					for (int j = 1; j <= 3; j++) {
						int temp = (i*3 + j) - 1;			//1, 2, 3, ... , 9	
						int xox = startxx + (j-1);
						int yoy = startyy - i;
						__toInstantiate = TableTiles[temp];
						Instantiate (__toInstantiate, new Vector3 ((float)xox*0.64f, (float)yoy*0.64f, 0f), Quaternion.identity);
					}
				}
				startyy -= 2;
			}
			startyy = 15;
			startxx += 3;
		}
			
		//outerwall before refrigerator

		Instantiate (wallTiles[3], new Vector3 ((float)23*0.64f, (float)-2*0.64f, 0f), Quaternion.identity);
		Instantiate (wallTiles[1], new Vector3 ((float)23*0.64f, (float)-1*0.64f, 0f), Quaternion.identity);
		Instantiate (wallTiles[0], new Vector3 ((float)23*0.64f, (float)0*0.64f, 0f), Quaternion.identity);

		// sink

		Instantiate (SinkTiles[0], new Vector3 ((float)23*0.64f, (float)5.5*0.64f, 0f), Quaternion.identity);
		Instantiate (SinkTiles[1], new Vector3 ((float)23*0.64f, (float)4.5*0.64f, 0f), Quaternion.identity);

		// sofa 
		Instantiate (SofaTiles[0], new Vector3 ((float)1*0.64f, (float)9*0.64f, 0f), Quaternion.identity);
		//Instantiate (SofaTiles[4], new Vector3 ((float)12*0.64f, (float)1.5*0.64f, 0f), Quaternion.identity);
		//Instantiate (SofaTiles[5], new Vector3 ((float)13*0.64f, (float)1.5*0.64f, 0f), Quaternion.identity);
		//Instantiate (SofaTiles[0], new Vector3 ((float)1*0.64f, (float)10*0.64f, 0f), Quaternion.identity);
		//Instantiate (SofaTiles[1], new Vector3 ((float)1*0.64f, (float)9*0.64f, 0f), Quaternion.identity);
		//Instantiate (SofaTiles[2], new Vector3 ((float)1*0.64f, (float)8*0.64f, 0f), Quaternion.identity);

		//book shelf
		Instantiate (Booksh, new Vector3 ((float)1*0.64f, (float)12*0.64f, 0f), Quaternion.identity);
		//Instantiate (BookshTiles[2], new Vector3 ((float)1*0.64f, (float)11*0.64f, 0f), Quaternion.identity);

		//printer
		Instantiate (PrinterTiles[0], new Vector3 ((float)16*0.64f, (float)2*0.64f, 0f), Quaternion.identity);
		Instantiate (PrinterTiles[1], new Vector3 ((float)17*0.64f, (float)2*0.64f, 0f), Quaternion.identity);
		Instantiate (PrinterTiles[2], new Vector3 ((float)16*0.64f, (float)1*0.64f, 0f), Quaternion.identity);
		Instantiate (PrinterTiles[3], new Vector3 ((float)17*0.64f, (float)1*0.64f, 0f), Quaternion.identity);

		//refrigerator
		Instantiate (Refrigerator, new Vector3 ((float)22.9*0.64f, (float)2.5*0.64f, 0f), Quaternion.identity);

		//bin
		Instantiate (Bin, new Vector3 ((float)6*0.64f, (float)6*0.64f, 0f), Quaternion.identity);

		//tea table
		//Instantiate (Teatable, new Vector3 ((float)13.5*0.64f, (float)5.5*0.64f, 0f), Quaternion.identity);

		//enter floor
		Instantiate (floorTiles[3], new Vector3 ((float)20*0.64f, (float)-2.0*0.64f, 0f), Quaternion.identity);
		Instantiate (floorTiles[3], new Vector3 ((float)19*0.64f, (float)-2.0*0.64f, 0f), Quaternion.identity);
		Instantiate (floorTiles[3], new Vector3 ((float)22*0.64f, (float)-2.0*0.64f, 0f), Quaternion.identity);
		Instantiate (floorTiles[3], new Vector3 ((float)21*0.64f, (float)-2.0*0.64f, 0f), Quaternion.identity);

		// mac
		Instantiate (Mac, new Vector3 ((float)6*0.64f, (float)14*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)6*0.64f, (float)10*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)12*0.64f, (float)12*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)12*0.64f, (float)8*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)15*0.64f, (float)10*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)22*0.64f, (float)8*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)22*0.64f, (float)12*0.64f, 0f), Quaternion.identity);
		Instantiate (Mac, new Vector3 ((float)22*0.64f, (float)14*0.64f, 0f), Quaternion.identity);

		// addition tree
		//Instantiate (TreeTiles[0], new Vector3 ((float)2*0.64f, (float)1.8*0.64f, 0f), Quaternion.identity);
		Instantiate (TreeTiles[1], new Vector3 ((float)1*0.64f, (float)15*0.64f, 0f), Quaternion.identity);
	}

	public void SetupScene()
	{
		BoardSetup ();
	}

	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/
}
