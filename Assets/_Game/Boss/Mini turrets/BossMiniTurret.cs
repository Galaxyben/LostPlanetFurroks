using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMiniTurret : MonoBehaviour {

	bool isAlive = true;
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire(){
		if (isAlive) { 
			Transform go = Mangos.PoolManager.Spawn (bullet, transform.position, Quaternion.identity);
			go.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 10, ForceMode.Impulse);
		}
	}
}
