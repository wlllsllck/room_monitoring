using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Unit : MonoBehaviour {

	public Vector2 target303, target302, target320;
	public Vector2 Lost_pos;
	public float speed = 0.02f;
	public float TimeInRoom = 0;
	int targetIndex;
	Vector2[] path;
	bool SwIsStart = false;
	public bool IsRight, IsLeft, IsUp, IsDown;
	GameObject connection;
	public string label = "target_15121_status";
	string IsFound303 = "Found_8-303";
	string IsFound302 = "Found_8-302";
	string IsFound320 = "Found_8-320";
	string IsLost = "Lost_8-320";
	string unit_id = "0";
	Unit_Animation unit_animation;
//	PopUp_Message popupmessage;
	Stopwatch sw = new Stopwatch ();
//	public string name = "WILL";
//	public Animator anim;

	void Start() {
//		anim = GetComponent<Animator>();
		connection = GameObject.Find ("Connection");
		unit_animation = GetComponent<Unit_Animation> ();
//		popupmessage = GetComponent<PopUp_Message> ();
		StartCoroutine ("Getdata");
	}

	IEnumerator Getdata() {
		yield return new WaitForSeconds (2);
		while (true) {
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
			yield return new WaitForSeconds (10);
		}
	}

	void Action(Data n) {
		if (n.note == IsFound302) {
			path = Pathfinding.RequestPath (transform.position, target302);
			if (!SwIsStart) {
				SwIsStart = true;
				sw.Start ();
			}
//			string message = name + " enter 302";
			StartCoroutine ("FollowPath");
//			StartCoroutine (ShowMessage (message, 4));
		} 
		else if (n.note == IsFound303) {
			path = Pathfinding.RequestPath (transform.position, target303);
			if (!SwIsStart) {
				SwIsStart = true;
				sw.Start ();
			}
//			string message = name + " enter 303";
			StartCoroutine ("FollowPath");
//			StartCoroutine (popupmessage.textPopUp(message, 2));
		} 
		else if (n.note == IsFound320) {
			path = Pathfinding.RequestPath (transform.position, target320);
			if (!SwIsStart) {
				SwIsStart = true;
				sw.Start ();
			}
			StartCoroutine ("FollowPath");
		} 
		else if (n.note == IsLost) {
			path = Pathfinding.RequestPath (transform.position, Lost_pos);
			if (SwIsStart == true) {
				SwIsStart = false;
				sw.Stop ();
				TimeInRoom += (sw.ElapsedMilliseconds * Mathf.Pow (10, -3) / 60);
				print ("time: " + TimeInRoom + " minutes");
			}
			StartCoroutine ("FollowPath");
		}
	}

//			foreach (_Node n in finalPath) {
//				print ("x: " + n.worldPosition.x + "y: " + n.worldPosition.y);

	void checkAnimation(Vector2 start, Vector2 des) {
		if ((start.y < des.y) && (start.x == des.x)) {
			IsUp = true;
			IsDown = false;
			IsLeft = false;
			IsRight = false;
		} 
		else if ((start.y > des.y) && (start.x == des.x)) {
			IsUp = false;
			IsDown = true;
			IsLeft = false;
			IsRight = false;
		} 
		else if ((start.x < des.x) && (start.y == des.y)) {
			IsUp = false;
			IsDown = false;
			IsLeft = false;
			IsRight = true;
		} 
		else if ((start.x > des.x) && (start.y == des.y)) {
			IsUp = false;
			IsDown = false;
			IsLeft = true;
			IsRight = false;
		}

	}

	IEnumerator FollowPath() {
		if (path.Length > 0) {
			targetIndex = 0;
			Vector2 beforecurrentWaypoint = (Vector2)transform.position;
			Vector2 currentWaypoint = path [0];
			int count = 0;
			while (true) {
				if ((Vector2)transform.position == currentWaypoint) {
					targetIndex++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path [targetIndex];
				}
				checkAnimation (beforecurrentWaypoint, currentWaypoint);
				if (unit_animation.SetAnimation(IsUp, IsDown, IsLeft, IsRight) && count > 10) {
					transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed);
					beforecurrentWaypoint = currentWaypoint;
				}
				else if (count <= 10){
					transform.position = Vector2.MoveTowards (transform.position, currentWaypoint, speed);
					beforecurrentWaypoint = currentWaypoint;
				}
				count++;
				if (beforecurrentWaypoint == path [path.Length-1]) {
					IsUp = false;
					IsDown = true;
					IsLeft = false;
					IsRight = false;
				}
				yield return new WaitForSeconds(0.02f);
			}
		}

	}

//	IEnumerator ShowMessage (string message, float delay) {
//		
//	}
	
}