using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class PathFollower : MonoBehaviour {
	Node [] PathNode;
	public GameObject Test_Member;
	// Use this for initialization
	public float MoveSpeed;
	float Timer;
	public int CurrentNode;
	int check = 0;	// default is 0, 1 is enter, -1 is exit
	Vector3 CurrentPositionHolder;
	public bool IsRight;
	public bool IsLeft;
	public bool IsUp;
	public bool IsDown;
	bool IsEnter = false;
	public string identity = "target_15121_status";
	public string IsFound = "Found_8-303";
	string IsLost = "Lost_8-320";
	GameObject connection;

	void Start () {
		PathNode = GetComponentsInChildren<Node> ();
		connection = GameObject.Find ("Connection");
//		Connection getdata = connection.GetComponent<Connection> ();
//		Debug.Log (getdata.label_data);
//		Debug.Log (getdata.note_data);
//		foreach (Node n in PathNode) {
//			Debug.Log (n.name);
//		}
		//Debug.Log(identity);
		CheckNode();
	}

	void CheckNode(){
		if (CurrentNode <= PathNode.Length - 1)
			Timer = 0;
		CurrentPositionHolder = PathNode [CurrentNode].transform.position;
	}

	void Enter(){
		Timer += Time.deltaTime * MoveSpeed;

		if (Test_Member.transform.position != CurrentPositionHolder) {
			CheckDirection (Test_Member.transform.position, CurrentPositionHolder);
			Test_Member.transform.position = Vector3.Lerp (Test_Member.transform.position, CurrentPositionHolder, Timer);
		} 
		else {
			if (CurrentNode < PathNode.Length - 1) {
				CurrentNode++;
				CheckNode ();
			} 
			else {
				check = 0;
			}
		}
	}

	void Exit(){
		Timer += Time.deltaTime * MoveSpeed;
		if (Test_Member.transform.position != CurrentPositionHolder) {
			CheckDirection (Test_Member.transform.position, CurrentPositionHolder);
			Test_Member.transform.position = Vector3.Lerp (Test_Member.transform.position, CurrentPositionHolder, Timer);
		} 
		else {
			if ((CurrentNode <= PathNode.Length - 1)&&(CurrentNode > 0)) {
					CurrentNode--;
					CheckNode ();
			} 
			else {
				check = 0;
			}
		}
	} 		

	void CheckDirection (Vector3 character, Vector3 holder){
		if ((character.y < holder.y) && (character.x == holder.x)) {
			IsUp = true;
			IsDown = false;
			IsLeft = false;
			IsRight = false;
		}
		if ((character.y > holder.y) && (character.x == holder.x)) {
			IsUp = false;
			IsDown = true;
			IsLeft = false;
			IsRight = false;
		}
		if ((character.x < holder.x) && (character.y == holder.y)) {
			IsUp = false;
			IsDown = false;
			IsLeft = false;
			IsRight = true;
		}
		if ((character.x > holder.x) && (character.y == holder.y)) {
			IsUp = false;
			IsDown = false;
			IsLeft = true;
			IsRight = false;
		}
	}

	void Update () {
		Connection getdata = connection.GetComponent<Connection> ();
//		Debug.Log (getdata.label_data);
//		Debug.Log (getdata.note_data);
		if (getdata.label_data_first == identity || getdata.label_data_second == identity) {
			if (getdata.label_data_first == identity) {
				if (IsEnter == false) {
					if (getdata.note_data_first == IsFound) {
						check = 1;
					}
					if (check == 1) {
						Enter ();
					} 
					else if (check == 0) {
						IsEnter = true;
						CheckNode ();
					}
				} 
				else if (IsEnter == true) {
					if (getdata.note_data_first == IsLost) {
						check = -1;
					}
					if (check == -1) {
						Exit ();
					}
					else if (check == 0) {
						IsEnter = false;
						CheckNode();
					}
				}
			} 
			if (getdata.label_data_second == identity) {
				if (IsEnter == false) {
					if (getdata.note_data_second == IsFound) {
						check = 1;
					}
					if (check == 1) {
						Enter ();
					} 
					else if (check == 0) {
						IsEnter = true;
						CheckNode ();
					}
				} 
				else if (IsEnter == true) {
					if (getdata.note_data_second == IsLost) {
						check = -1;
					}
					if (check == -1) {
						Exit ();
					}
					else if (check == 0) {
						IsEnter = false;
						CheckNode();
					}
				}
			}

		}

	}
}
