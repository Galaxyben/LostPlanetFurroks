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
		private int life;
		private float bulletvel;
		private float movementSpeed;
		private float impulse = 15.0f;
		public int gunType;
		public Rigidbody rigi;
		private Camera mainCamera;
		private float distance = 100f;
		private RectTransform pointer;
		private Vector3 aim;
		private Vector3 pntrPos;
		private Vector3 mousePos;
		private GameObject PointerPrefab;
		public Vector3 offset;
		float xRotate, yRotate;
		Vector3 temp1, temp2;

		void Start () {
			PointerPrefab = GameObject.Find ("Pointer");
			mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			pointer = GameObject.Find ("Pointer").GetComponent<RectTransform> ();
			Mangos.PoolManager.PreSpawn (Bullet.gameObject, 10);
			Mangos.PoolManager.SetPoolLimit (Bullet.gameObject, 100);
			Mangos.PoolManager.PreSpawn (HMBullet.gameObject, 10);
			Mangos.PoolManager.SetPoolLimit (HMBullet.gameObject, 100);
			offset = PointerPrefab.transform.position - transform.position;
			offset.z = 0;
			life = 100;
			bulletvel = 50.0f;
			movementSpeed = 35.0f;
			gunType = 1;
		}

		void Awake(){
			StaticManager.playerShip = this;
		}

		void Update () {
			mousePos = Input.mousePosition;
			pntrPos = Camera.main.WorldToScreenPoint (PointerPrefab.transform.position);
			//pntrPos = transform.position;
			mousePos += Camera.main.transform.forward * distance;
			//aim = Camera.main.ScreenToWorldPoint (pntrPos);

			if (gunType == 5){
				gunType = 1;
			}

			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				movementSpeed = movementSpeed * 2;
			} else {
				movementSpeed = 45.0f;
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
			Vector3 direction = new Vector3 (xAxis * -1, yAxis, 0f) + transform.forward;
			direction.Normalize ();
			transform.Translate (direction * movementSpeed * Time.deltaTime, Space.Self);

			transform.position += direction * movementSpeed * Time.deltaTime;
		}

		public void pointerMovement(float xAxis, float yAxis)	{
			Vector3 pointerPos = new Vector3 (xAxis * 960, yAxis * 540, 0.0f);
			PointerPrefab.transform.localPosition = Vector3.Lerp(PointerPrefab.transform.localPosition, pointerPos, Time.deltaTime*3f);
			Vector3 lookat = transform.TransformDirection (new Vector3 (xAxis, yAxis, 0f));
			transform.LookAt (lookat);

		}
		
		public void Shoot(){
				switch (gunType) {
				case 1: //First Typical Gun
					bulletvel = 100.0f;
					Transform TypicBullet = Mangos.PoolManager.Spawn (Bullet.gameObject, ShootingPlace.transform.position, ShootingPlace.transform.rotation);
					TypicBullet.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);

					break;
				case 2://Dual Gun Shot
					bulletvel = 130.0f;
					Transform DBullet1 = Mangos.PoolManager.Spawn (Bullet.gameObject, DGun1.transform.position, DGun1.transform.rotation);
					DBullet1.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					Transform DBullet2 = Mangos.PoolManager.Spawn (Bullet.gameObject, DGun2.transform.position, DGun2.transform.rotation);
					DBullet2.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				case 3://Cannon Shot
					bulletvel = 80.0f;
					Transform newBulletCS = Mangos.PoolManager.Spawn (Bullet.gameObject, ShootingPlace.transform.position, ShootingPlace.transform.rotation);
					newBulletCS.gameObject.GetComponent<Rigidbody>().AddForce (transform.forward * bulletvel, ForceMode.VelocityChange);
					break;
				case 4://Homming Shot
					bulletvel = 115.0f;
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
