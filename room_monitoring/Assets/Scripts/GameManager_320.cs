using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_320 : MonoBehaviour {

	public static GameManager_320 instance = null;
	private BoardManager_320 boardScript;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager_320> ();
		InitGame ();
	}


	void InitGame()
	{
		boardScript.SetupScene ();
	}

}
