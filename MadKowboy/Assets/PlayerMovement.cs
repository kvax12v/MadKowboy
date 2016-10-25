using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 10f;
	public float jump = 5f;
	public bool facingRight = true;
	Rigidbody2D rigid;
	public bool grounded;
	public Transform childPos;
	public LayerMask groundLayer;
	Animator animation;
	// Use this for initialization
	void Start () {
		animation = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {



		childPos = this.gameObject.transform.GetChild (0);

		float move = Input.GetAxis ("Horizontal");
		rigid.velocity = new Vector2 (move * maxSpeed, rigid.velocity.y); 


	
		RaycastHit2D land = Physics2D.Raycast (childPos.position, Vector2.down, .001f);
		Debug.DrawRay (childPos.position, Vector2.down);

		Debug.Log (land.collider);

		if (land.collider != null) {
			grounded = true;
		}

		if (Input.GetKeyDown("w") && grounded == true) {
			grounded = false;
			Debug.Log (grounded);
			rigid.velocity = new Vector2 (rigid.velocity.x, maxSpeed);
			rigid.AddForce (rigid.velocity);
			Debug.Log(grounded);
		}


		//if the player is pressing right key and facing right is false, then we flip it so facingright is true and the scale's x is reversed
		if (move > 0 && !facingRight) {
			Flip ();

		//else if the player is pressing left and facining right is true, then we flip it so facingright is false and the scale's x is reversed
		}else if(move <0 && facingRight){
			Flip();
		}



		if(rigid.velocity.x > 0){
			animation.SetInteger ("State", 1);
			
		}


	
	}

	void Flip(){
		//Changes facingRight to opposite and changee scale's x coordinate to opposite(changes orientation of character to opposite)

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	
	}

}
