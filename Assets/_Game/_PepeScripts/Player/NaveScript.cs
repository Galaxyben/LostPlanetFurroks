using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
public class NaveScript : MonoBehaviour {
	public GameObject Nave;
	[Tooltip("Lugar dónde saldran los disparos")]
	public GameObject ShootingPlace;
	public GameObject DGun1;
	public GameObject DGun2;
	public Rigidbody Bullet;
	private int bulletForce;
	private int bombForce;
	private int life;
	private float bulletvel;
	private float movementSpeed;
	private float impulse = 5.0f;
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
			if (gunType == 5){
				gunType = 1;
			}
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
				bulletvel = 40.0f;
				Rigidbody TypicBullet = Instantiate (Bullet, ShootingPlace.transform.position, ShootingPlace.transform.rotation) as Rigidbody;
				TypicBullet.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
				break;
			case 2://Dual Gun Shot
				bulletvel = 60.0f;
				Rigidbody DBullet1 = Instantiate (Bullet, DGun1.transform.position, DGun1.transform.rotation) as Rigidbody;
				DBullet1.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
				Rigidbody DBullet2 = Instantiate (Bullet, DGun2.transform.position, DGun2.transform.rotation) as Rigidbody;
				DBullet2.AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
				break;
			case 3://Cannon Shot
				bulletvel = 20.0f;
				Rigidbody newBulletCS = Instantiate (Bullet, ShootingPlace.transform.position, ShootingPlace.transform.rotation) as Rigidbody;
				newBulletCS.AddForce (transform.forward * bulletvel/2, ForceMode.VelocityChange);
				break;
			case 4://Homming Shot
				bulletvel = 60.0f;

				break;
			default:
				gunType = 1;
				break;
			}
		}
}
}
