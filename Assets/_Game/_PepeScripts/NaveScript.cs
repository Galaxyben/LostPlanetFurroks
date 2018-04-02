using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveScript : MonoBehaviour {
	public GameObject Nave;
	[Tooltip("Lugar dónde saldran los disparos")]
	public GameObject ShootingPlace;
	public Rigidbody Bullet;
	private int bulletForce = 10;
	private int bombForce = 15;
	private int life = 100;
	private float bulletvel = 50.0f;
	private float movementSpeed = 10.0f;
	public Rigidbody rigi;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Movement_H = Input.GetAxis ("Horizontal");
		float Movement_V = Input.GetAxis ("Vertical");

		Vector3 direction = new Vector3 (Movement_H, Movement_V, 0);
		Vector3 FDir = new Vector3 (Movement_H, Movement_V, 1.0f);

		transform.position += direction * movementSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (FDir), Mathf.Deg2Rad * 50.0f);

		if (Input.GetButtonDown ("Fire1")) {
			Rigidbody newBullet = Instantiate (Bullet, transform.position, transform.rotation) as Rigidbody;
			newBullet.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
		}

		if ((Movement_H <= -0.05 && Input.GetKeyDown (KeyCode.JoystickButton2)) || (Movement_H <= -0.05 && Input.GetKeyDown (KeyCode.Q))) {
			rigi.AddRelativeForce (Vector3.left * 30, ForceMode.Impulse);
		}
		if (Movement_H >= 0.05 && Input.GetKeyDown (KeyCode.JoystickButton2)) {
			rigi.AddRelativeForce (Vector3.right * 30, ForceMode.Impulse);
		}
	}
}
