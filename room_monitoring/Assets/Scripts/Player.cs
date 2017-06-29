using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public float playerSpeed = 0.1f;
	public LayerMask BlockingLayer;

	private BoxCollider2D _BoxCollider;
	//private Rigidbody2D _Rigidbody;
	//private Animator _Animator;
	//private float inverseMoveTime; 

	//private float xDir;
	//private float yDir;	

	void Start () 
	{
		_BoxCollider = GetComponent<BoxCollider2D>();
		//_Rigidbody = GetComponent<Rigidbody2D>();
		//_Animator = GetComponent<Animator> ();
		//inverseMoveTime = 1f / playerSpeed;
	}

	void Move(float xDir, float yDir)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);

		_BoxCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast (start, end, BlockingLayer);
		_BoxCollider.enabled = true;

		if (hit.transform == null) {
			transform.Translate(new Vector2 (xDir, yDir) * playerSpeed);
			print ("move");
			//return true;
		} 
		else {
			print ("hit");
			return;
			//return false;
		}
	}
	
	void AttempMove (float xDir, float yDir)
	{
		//RaycastHit2D hit;
		//bool canMove = Move (xDir, yDir, out hit);

		//if (hit.transform == null)
			//return;

		//T hitComponent = hit.transform.GetComponent <T> ();
		//if (!canMove && hitComponent != null) {
		//	print ("can't move");
		//}
		Move(xDir, yDir);

	}
		
	void Update () 
	{
		float horizontal = 0;
		float vertical = 0;

		horizontal = (float) (Input.GetAxisRaw ("Horizontal")) * 0.80f;
		vertical = (float) (Input.GetAxisRaw ("Vertical")) * 0.80f;

		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0) {
			AttempMove (horizontal, vertical);
		}
	}
}

/*
public class Player : MovingObject {

	private Animator animator;


	// Use this for initialization
	protected override void Start () {
		animator = GetComponent<Animator> ();
		base.Start ();
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);
	}
*/
	// Update is called once per frame
/*
	void Update () {
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int)Input.GetAxisRaw ("Horizontal");
		vertical = (int)Input.GetAxisRaw ("Vertical");

		if (horizontal != 0)
			vertical = 0;

		//if (horizontal != 0 || vertical != 0)
		//	AttemptMove<Wall> (horizontal, vertical);
	}


	protected override void OnCantMove <T> (T component)
	{
		
	}

}
*/