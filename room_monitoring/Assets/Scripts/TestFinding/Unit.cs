using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Vector2 target303, target302, target320;
	public Vector2 Lost_pos;
	public float speed = 10;
	int targetIndex;
	Vector2[] path;
	bool IsEnter = false;
	GameObject connection;
	public string label = "target_15121_status";
	string IsFound303 = "Found_8-303";
	string IsFound302 = "Found_8-302";
	string IsFound320 = "Found_8-320";
	string IsLost = "Lost_8-320";
	string unit_id = "0";

	void Start() {
		connection = GameObject.Find ("Connection");
	}

	void Update() {
		Connection getdata = connection.GetComponent<Connection> ();
		foreach (Data n in getdata.current_data) {
//				print ("id: " + n.id + " label: " + n.label + " note: " + n.note);
			if (label == n.label) {
				int _n_id = int.Parse (n.id);
				int _unit_id = int.Parse (unit_id);
				if (_n_id > _unit_id) {
					Action (n);
					unit_id = n.id;
				}
			}
		}
	}

	void Action(Data n) {
		if (n.note == IsFound302) {
			path = Pathfinding.RequestPath (transform.position, target302);
			StartCoroutine ("FollowPath");
		} 
		else if (n.note == IsFound303) {
			path = Pathfinding.RequestPath (transform.position, target303);
			StartCoroutine ("FollowPath");
		} 
		else if (n.note == IsFound320) {
			path = Pathfinding.RequestPath (transform.position, target320);
			StartCoroutine ("FollowPath");
		} 
		else if (n.note == IsLost) {
			path = Pathfinding.RequestPath (transform.position, Lost_pos);
			StartCoroutine ("FollowPath");
		}
	}

//			foreach (_Node n in finalPath) {
//				print ("x: " + n.worldPosition.x + "y: " + n.worldPosition.y);

	IEnumerator FollowPath() {
		if (path.Length > 0) {
			targetIndex = 0;
			Vector2 currentWaypoint = path [0];

			while (true) {
				if ((Vector2)transform.position == currentWaypoint) {
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}

				transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);
				yield return null;

			}
		}
	}
	
}