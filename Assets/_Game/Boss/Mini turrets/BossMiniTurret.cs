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
			if(go)
				go.gameObject.GetComponent<Rigidbody> ().AddForce ((go.position - GetComponentInParent<BossCenter>().gameObject.transform.position)* 10, ForceMode.Impulse);
		}
	}
}
