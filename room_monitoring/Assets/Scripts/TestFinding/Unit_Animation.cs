using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Animation : MonoBehaviour {

	public Animator anim;
//	GameObject character;

	void Start() {
		anim = GetComponent<Animator>();
//		character = GameObject.Find ("Peak");
	}

	public bool SetAnimation(bool IsUp, bool IsDown, bool IsLeft, bool IsRight) {
//		Unit direction = character.GetComponent<Unit> ();
		if (IsUp) {
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("Up", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("WalkUp", true);

			print ("IsUp");
			return true;
		} 
		else if (IsDown) {
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("Down", true);
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("WalkDown", true);

			print ("IsDown");
			return true;
		} 
		else if (IsLeft) {
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkRight", false);
			anim.SetBool ("Left", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
			anim.SetBool ("WalkLeft", true);

			print ("IsLeft");
			return true;
		} 
		else if (IsRight) {
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("WalkRight", true);

			print ("IsRight");
			return true;
		} 
		else {
			print ("stay still");
			return false;
		}
	}

}
