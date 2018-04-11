using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMiniTurret : MonoBehaviour {

	bool isAlive = true;
	public GameObject bullet;
	public int id;
	public char Group;
	float FireRate;
	float ogFireRate;
	bool canFire = true;
	// Use this for initialization
	void Start () {
		FireRate = GetComponentInParent<BossCenter> ().FireRate;
		ogFireRate = FireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if (canFire == false) {
			FireRate -= Time.deltaTime/ogFireRate;
		}
		if (FireRate <= 0f) {
			canFire = true;
		}
	}

	public void Fire(float _f){
		if (isAlive && canFire) { 
			Transform go = Mangos.PoolManager.Spawn (bullet, transform.position, Quaternion.identity);
			Vector3 dir = new Vector3 ((go.position - GetComponentInParent<BossCenter> ().gameObject.transform.position).x, 0, (go.position - GetComponentInParent<BossCenter> ().gameObject.transform.position).z);
			if(go)
				go.gameObject.GetComponent<Rigidbody> ().AddForce (dir * _f, ForceMode.Impulse);
			canFire = false;
			FireRate = ogFireRate;
		}
	}
}
