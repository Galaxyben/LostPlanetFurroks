using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos {
	public class NaveScript : MonoBehaviour {
		public GameObject Nave;
		[Tooltip("Lugar dónde saldran los disparos")]
		public GameObject ShootingPlace;
		public GameObject DGun1;
		public GameObject DGun2;
		public Rigidbody Bullet;
		public Rigidbody HMBullet;
		private int bulletForce;
		private int bombForce;
		private int life;
		private float bulletvel;
		private float movementSpeed;
		private float impulse = 5.0f;
		public int gunType;
		public Rigidbody rigi;
		private Camera mainCamera;
		private float distance = 100f;
		private RawImage pointer;
		private Vector2 pointerPos;
		private Vector3 aim;
		private Vector3 mousePos;

		void Start () {
			mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			Mangos.PoolManager.PreSpawn (Bullet.gameObject, 10);
			Mangos.PoolManager.SetPoolLimit (Bullet.gameObject, 100);
			Mangos.PoolManager.PreSpawn (HMBullet.gameObject, 10);
			Mangos.PoolManager.SetPoolLimit (HMBullet.gameObject, 100);
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
			mousePos = Input.mousePosition;
			mousePos += Camera.main.transform.forward * distance;
			aim = Camera.main.ScreenToWorldPoint (mousePos);

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
			//transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (FDir), Mathf.Deg2Rad * 70.0f);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (aim), Mathf.Deg2Rad * 100.0f);
		}
		
		public void Shoot(){
				switch (gunType) {
				case 1: //First Typical Gun
					bulletvel = 40.0f;
					Transform TypicBullet = Mangos.PoolManager.Spawn (Bullet.gameObject, ShootingPlace.transform.position, ShootingPlace.transform.rotation);
					TypicBullet.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				case 2://Dual Gun Shot
					bulletvel = 60.0f;
					Transform DBullet1 = Mangos.PoolManager.Spawn (Bullet.gameObject, DGun1.transform.position, DGun1.transform.rotation);
					DBullet1.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					Transform DBullet2 = Mangos.PoolManager.Spawn (Bullet.gameObject, DGun2.transform.position, DGun2.transform.rotation);
					DBullet2.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				case 3://Cannon Shot
					bulletvel = 20.0f;
					Transform newBulletCS = Mangos.PoolManager.Spawn (Bullet.gameObject, ShootingPlace.transform.position, ShootingPlace.transform.rotation);
					newBulletCS.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				case 4://Homming Shot
					bulletvel = 60.0f;
					Transform HommingBullet = Mangos.PoolManager.Spawn (HMBullet.gameObject, ShootingPlace.transform.position, ShootingPlace.transform.rotation);
					HommingBullet.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				default:
					gunType = 1;
					break;
				}
		}

		public void getDamage() {

		}
	}
}
