using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour {
	public GameObject Nave;
	[Tooltip("Lugar dónde saldran los disparos")]
	public GameObject ShootingPlace;
	public Rigidbody Bullet;
	private float bulletvel = 10.0f;
	public float movementSpeed = 8.0f;
	Rigidbody rigi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"),Input.GetAxis ("Vertical"), 0)*movementSpeed*Time.deltaTime;

		if (Input.GetButtonDown ("Fire1")) {
			Rigidbody newBullet = Instantiate (Bullet, transform.position, Bullet.rotation) as Rigidbody;
			newBullet.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
		}
	}
}
