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
	private float impulse = 30.0f;
	public int gunType;
	public Rigidbody rigi;

	void Start () {
			life = 100;
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
				Vector3 direction = new Vector3 (xAxis, 0, 0);
				transform.position += direction * movementSpeed * Time.deltaTime * impulse;
			}
			if ((xAxis >= 0.05)) {
				Vector3 direction = new Vector3 (xAxis, 0, 0);
				transform.position += direction * movementSpeed * Time.deltaTime * impulse;
			}
			if (yAxis >= 0.05) {
					Vector3 direction = new Vector3 (0, yAxis, 0);
					transform.position += direction * movementSpeed * Time.deltaTime * impulse;
			}
			if (yAxis <= -0.05) {
				Vector3 direction = new Vector3 (0, yAxis, 0);
				transform.position += direction * movementSpeed * Time.deltaTime * impulse;
			}
	}

	public void Movement(float xAxis, float yAxis){
		Vector3 direction = new Vector3 (xAxis, yAxis, 0);
			Vector3 FDir = new Vector3 (xAxis, yAxis, 1.0f);
		transform.position += direction * movementSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (FDir), Mathf.Deg2Rad * 70.0f);
	}
	
		public void Shoot(){
			switch (gunType) {
			case 1: //First Typical Gun
				Rigidbody newBullet = Instantiate (Bullet, transform.position, transform.rotation) as Rigidbody;
				newBullet.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
				break;
			case 2://Dual Gun Shot

				break;
			case 3://Cannon Shot
				Rigidbody newBulletCS = Instantiate (Bullet, transform.position, transform.rotation) as Rigidbody;
				newBulletCS.AddForce (transform.forward * bulletvel/2, ForceMode.VelocityChange);
				break;
			case 4://Homming Shot

				break;
			default:
				gunType = 1;
				break;
			}
		}
}
}
