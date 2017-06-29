using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Member1Movement : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			//transform.Translate (new Vector2 (-20, 0) * speed);
//			//iTween.MoveBy(gameObject,iTween.Hash(
//				"x"   , -5,
//				"time", 0.5f
//			));

		}
	}
}
