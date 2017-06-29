using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
			anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("up"))//Press up arrow key to move forward on the Y AXIS
		{
			anim.SetBool ("Up", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
		}
		if(Input.GetKey("down"))//Press up arrow key to move forward on the Y AXIS
		{
			anim.SetBool ("Down", true);
			anim.SetBool ("Up", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Right", false);
		}
		if(Input.GetKey("left"))//Press up arrow key to move forward on the Y AXIS
		{
			anim.SetBool ("Left", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Up", false);
			anim.SetBool ("Right", false);
		}
		if(Input.GetKey("right"))//Press up arrow key to move forward on the Y AXIS
		{
			anim.SetBool ("Right", true);
			anim.SetBool ("Down", false);
			anim.SetBool ("Left", false);
			anim.SetBool ("Up", false);
		}


		if (Input.GetKey ("up")) {
			anim.SetBool ("WalkUp", true);
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkRight", false);
		} 
		else {
			anim.SetBool ("WalkUp", false);
		}
			
		if(Input.GetKey("down")){
			anim.SetBool ("WalkDown", true);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkRight", false);
		} 
		else {
			anim.SetBool ("WalkDown", false);
		}

		if(Input.GetKey("left")){
			anim.SetBool ("WalkLeft", true);
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkUp", false);
			anim.SetBool ("WalkRight", false);
		} 
		else {
			anim.SetBool ("WalkLeft", false);
		}

		if(Input.GetKey("right")){
			anim.SetBool ("WalkRight", true);
			anim.SetBool ("WalkDown", false);
			anim.SetBool ("WalkLeft", false);
			anim.SetBool ("WalkUp", false);
		} 
		else {
			anim.SetBool ("WalkRight", false);
		}

	}
}
