using System.Collections;
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
//	public string id_data_first;
//	public string id_data_second;
//	public string id_data_third;
//
//	public string label_data_first;
//	public string label_data_second;
//	public string label_data_third;
//
//	public string note_data_first;
//	public string note_data_second;
//	public string note_data_third;
	public List<Data> current_data;

	void Awake()
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
	} 

	private void Processjson(string jsonString)
	{
		current_data = new List<Data>();
		JsonData jsonvale = JsonMapper.ToObject(jsonString);
		parseJSON parsejson;
		parsejson = new parseJSON();
//		current_data = new Data[5];
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
			parsejson.id.Add(jsonvale[i]["id"].ToString());
//			parsejson.timestamp.Add(jsonvale[i]["timestamp"].ToString());
			parsejson.label.Add(jsonvale[i]["label"].ToString());
			//parsejson.value.Add(jsonvale[i]["value"].ToString());
			parsejson.note.Add(jsonvale[i]["note"].ToString());
		}

		for(int i = 0; i<5; i++)
		{
			current_data.Add(new Data ((string)parsejson.id [i], (string)parsejson.label [i], (string)parsejson.note [i]));
		}
//
//		id_data_first = (string)parsejson.id [0];
//		id_data_second = (string)parsejson.id [1];
//		id_data_third = (string)parsejson.id [2];
//
//		label_data_first = (string)parsejson.label [0];
//		label_data_second = (string)parsejson.label [1];
//		label_data_third = (string)parsejson.label [2];
//
//		note_data_first = (string)parsejson.note [0];
//		note_data_second = (string)parsejson.note [1];
//		note_data_third = (string)parsejson.note [2];
	}
}

