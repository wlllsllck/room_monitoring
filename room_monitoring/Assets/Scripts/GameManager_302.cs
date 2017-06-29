using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_302 : MonoBehaviour {

	public static GameManager_302 instance = null;
	private BoardManager_302 boardScript;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager_302> ();
		InitGame ();
	}


	void InitGame()
	{
		boardScript.SetupScene ();
	}
}
