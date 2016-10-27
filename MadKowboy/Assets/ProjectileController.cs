using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Enemy") {
			Debug.Log ("Enemy hit");
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}



	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
