using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject boomGun;
	public float force = 100f;
	Rigidbody2D rigid;
	public float maxSpeed = 10f;
	Vector2 direction;
	public AudioSource audioSource;
	private PlayerMovement playerMovement;
	bool facingRight;
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;
	GameObject KrazyKowboy;

	// Use this for initialization
	void Start () {
		KrazyKowboy = GameObject.Find("KrazyKowboy");
		playerMovement = KrazyKowboy.GetComponent<PlayerMovement> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetButton ("Fire1") && cooldownTimer <= 0) {
			GameObject ballInstance;
			ballInstance = Instantiate (boomGun, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
			rigid = ballInstance.GetComponent<Rigidbody2D> ();
			direction = rigid.velocity + ((Vector2)transform.right * maxSpeed);
			//Check if is facingRight from PlayerMovement script
			if (playerMovement.facingRight) {
				rigid.AddForce (direction * force);
			} else {
			rigid.AddForce (-direction * force); //Shoot left
			}
			rigid.velocity = transform.forward * maxSpeed;
			Debug.Log ("Boom gun goes off!");
			cooldownTimer = fireDelay;

		}
	
	}
}
