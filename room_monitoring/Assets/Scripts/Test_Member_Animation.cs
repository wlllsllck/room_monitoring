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
	public string PathID = "Peak_Path";

	void Start () {
		anim = GetComponent<Animator>();
		Path = GameObject.Find (PathID);
//		objectposition = path.Test_Member.transform.position;
//		currentpositionholder = path.CurrentPositionHolder;
		//Debug.Log ("Start");
	}
	// Update is called once per frame
	void Update () {
		PathFollower path = Path.GetComponent<PathFollower> ();

		if (path.IsUp) {
			anim.SetBool ("Up", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
		}

		if (path.IsDown) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", true);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
		}

		if (path.IsLeft) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", true);
			anim.SetBool ("Right", false);
		}

		if (path.IsRight) {
			anim.SetBool ("Up", false);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", true);
		}


//		if (objectposition != currentpositionholder) {
//				if (objectposition.x == currentpositionholder.x) { 
//			if ((objectposition.y <currentpositionholder.y) && (objectposition.x == currentpositionholder.x)) {
//
//						anim.SetBool ("Up", true);
//						anim.SetBool ("Down", false);
//						anim.SetBool ("Left", false);
//						anim.SetBool ("Right", false);
//			}
//					
//			if((objectposition.y > currentpositionholder.y) && (objectposition.x == currentpositionholder.x)){
//			
//						anim.SetBool ("Up", false);
//						anim.SetBool ("Down", true);
//						anim.SetBool ("Left", false);
//						anim.SetBool ("Right", false);
//			}
//
//			if ((objectposition.x < currentpositionholder.x) && (objectposition.y == currentpositionholder.y)) {
//
//						anim.SetBool ("Up", false);
//						anim.SetBool ("Down", false);
//						anim.SetBool ("Left", false);
//						anim.SetBool ("Right", true);
//			}
//
//			if ((objectposition.x > currentpositionholder.x) && (objectposition.y == currentpositionholder.y)) {
//			
//					anim.SetBool ("Up", false);
//					anim.SetBool ("Down", false);
//					anim.SetBool ("Left", true);
//					anim.SetBool ("Right", false);
//			} 
			
	}
}

////Debug.Log (objectposition.x);
//Debug.Log ("y(o) :" + objectposition.y); 
////Debug.Log (currentpositionholder.x);
//Debug.Log ("y(c) :" + currentpositionholder.y);