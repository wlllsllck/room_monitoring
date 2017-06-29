using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Member_Animation : MonoBehaviour {

	public Animator anim;
//	Node[] PathNode;
//	int currentNode;	// initial 0
//	static Vector3currentpositionholder;
	//public GameObject Path;
//	int up = 0;
//	int down = 0;
//	int right = 0;
//	int left = 0;
	// Use this for initialization
	GameObject Path;
	Vector3 objectposition;
	Vector3 currentpositionholder;

	void Start () {
		anim = GetComponent<Animator>();
		Path = GameObject.Find ("Will_Path");
//		PathFollower path = Path.GetComponent<PathFollower> ();
//		objectposition = path.Test_Member.transform.position;
//		currentpositionholder = path.CurrentPositionHolder;
		//Debug.Log ("Start");
//		CheckNode();
	}

//	void CheckNode(){
//		CurrentPositionHolder = PathNode[currentNode].objectposition;
//	}

	// Update is called once per frame
	void Update () {
		PathFollower path = Path.GetComponent<PathFollower> ();
		objectposition = path.Test_Member.transform.position;
		currentpositionholder = path.CurrentPositionHolder;
//		Debug.Log (objectposition.x);
//		Debug.Log (objectposition.y);
//		Debug.Log (currentpositionholder.x);
//		Debug.Log (currentpositionholder.y);
		if (objectposition != currentpositionholder) {
				if (objectposition.x == currentpositionholder.x) {
					if (objectposition.y <currentpositionholder.y) {
						anim.SetBool ("Up", true);
						anim.SetBool ("Down", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
						//up = 1;
//												anim.SetBool ("WalkUp", true);
//												anim.SetBool ("WalkDown", false);
//												anim.SetBool ("WalkLeft", false);
//												anim.SetBool ("WalkRight", false);
					}
					else if(objectposition.y > currentpositionholder.y){
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", true);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", false);
						//down = 1;
//											anim.SetBool ("WalkUp", false);
//											anim.SetBool ("WalkDown", true);
//											anim.SetBool ("WalkLeft", false);
//											anim.SetBool ("WalkRight", false);
					}
				}
				else if (objectposition.y == currentpositionholder.y) {
					if (objectposition.x < currentpositionholder.x) {
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", false);
						anim.SetBool ("Left", false);
						anim.SetBool ("Right", true);
						//right = 1;
//											anim.SetBool ("WalkUp", false);
//											anim.SetBool ("WalkDown", false);
//											anim.SetBool ("WalkLeft", false);
//											anim.SetBool ("WalkRight", true);
					}
					else if(objectposition.x > currentpositionholder.x){
						anim.SetBool ("Up", false);
						anim.SetBool ("Down", false);
						anim.SetBool ("Left", true);
						anim.SetBool ("Right", false);
//						//left = 1;
//											anim.SetBool ("WalkUp", false);
//											anim.SetBool ("WalkDown", false);
//											anim.SetBool ("WalkLeft", true);
//											anim.SetBool ("WalkRight", false);
					}
				}
		} 
//		else {
//			if (currentNode < PathNode.Length - 1) {
//				currentNode++;
//				CheckNode ();
//			}
//		}
	}
}
