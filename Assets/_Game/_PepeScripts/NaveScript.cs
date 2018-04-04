using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
public class NaveScript : MonoBehaviour {
	public GameObject Nave;
	[Tooltip("Lugar dónde saldran los disparos")]
	public GameObject ShootingPlace;
	public Rigidbody Bullet;
	private int bulletForce;
	private int bombForce;
	private int life;
	private float bulletvel;
	private float movementSpeed;
	public int gunType;
	public Rigidbody rigi;

	// Use this for initialization
	void Start () {
			life = 1000;
			bulletForce = 10;
			bombForce = 30;
			bulletvel = 50.0f;
			movementSpeed = 10.0f;
			gunType = 1;
	}

	void Awake(){
		StaticManager.playerShip = this;
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void Dash(float xAxis, float yAxis){
		if ((xAxis <= -0.05)) {
			rigi.AddRelativeForce (Vector3.left * 30, ForceMode.Impulse);
		}
		if (yAxis >= 0.05) {
			rigi.AddRelativeForce (Vector3.right * 30, ForceMode.Force);
		}
	}

	public void Movement(float xAxis, float yAxis){
		Vector3 direction = new Vector3 (xAxis, yAxis, 0);
		Vector3 FDir = new Vector3 (xAxis, yAxis, 1.0f);
		transform.position += direction * movementSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (FDir), Mathf.Deg2Rad * 50.0f);
	}
	
		public void Shoot(){
			switch (gunType) {
			case 1: //First Typical Gun
				Rigidbody newBullet = Instantiate (Bullet, transform.position, transform.rotation) as Rigidbody;
				newBullet.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
				break;
			case 2://Dual Gun Shot

				break;
			case 3:

				break;
			case 4:

				break;
			default:
				gunType = 1;
				break;
			}
		}
}
}
