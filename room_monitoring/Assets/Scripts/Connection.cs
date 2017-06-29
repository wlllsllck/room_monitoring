﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class parseJSON
{
	public ArrayList id;
	public ArrayList timestamp;
	public ArrayList label;
	public ArrayList value;
	public ArrayList note;
}


public class Connection : MonoBehaviour {

	//WWW get;
	bool continueRequest = false;
	public string label_data;
	public string note_data;

	void Start()
	{
		StartCoroutine (WaitForRequest ());
	}

	IEnumerator WaitForRequest()
	{
//		if (continueRequest)
//			yield break;
//
		continueRequest = true;

		float requestFrequencyInSec = 5f;
		WaitForSeconds waitTime = new WaitForSeconds(requestFrequencyInSec);

		while (continueRequest) {
			string url = "http://localhost:3000";
			WWW get = new WWW(url);
			yield return get;
			if (get.error == null)
			{
				Processjson(get.data);
				//Debug.Log (parseJSON [0] ["id"]);
			}
			else
			{
				Debug.Log("ERROR: " + get.error);
			}    
			yield return waitTime;
		}
//		yield return get;

	} 

	private void Processjson(string jsonString)
	{
		JsonData jsonvale = JsonMapper.ToObject(jsonString);
		parseJSON parsejson;
		parsejson = new parseJSON();
//		parsejson.title = jsonvale["title"].ToString();
//		parsejson.id = jsonvale["ID"].ToString();

		parsejson.id = new ArrayList ();
		parsejson.timestamp = new ArrayList ();
		parsejson.label = new ArrayList ();
		parsejson.value = new ArrayList ();
		parsejson.note = new ArrayList ();

//		Debug.Log (jsonvale.Count);
//		Debug.Log (jsonvale[0]["id"].ToString());
		for(int i = 0; i<5; i++)
		{
			//parsejson.id.Add(jsonvale[i]["id"].ToString());
			parsejson.timestamp.Add(jsonvale[i]["timestamp"].ToString());
			parsejson.label.Add(jsonvale[i]["label"].ToString());
			//parsejson.value.Add(jsonvale[i]["value"].ToString());
			parsejson.note.Add(jsonvale[i]["note"].ToString());
		}    
		Debug.Log (parsejson.timestamp[0]);
		Debug.Log (parsejson.label[0]);
		label_data = (string)parsejson.label [0];
		Debug.Log (parsejson.note[0]);
		note_data = (string)parsejson.note [0];
	}
}

