using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date_Time : MonoBehaviour {

	public string datetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			PlayerPrefs.SetString("date time", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
			datetime = PlayerPrefs.GetString ("date time");
			Debug.Log(datetime);
		}
	}
}
