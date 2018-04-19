using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonGrunt : MonoBehaviour {

	GameObject target;
	public float GunDelay;
	public float FiresPerBarrage;
	public float BarrageDeleay;
	float ogGD;
	float ogBD;
	// Use this for initialization
	void Start () {
		ogGD = GunDelay;
		ogBD = BarrageDeleay;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			BarrageDeleay -= Time.deltaTime;
			if (BarrageDeleay <= 0) {
				BarrageDeleay = ogBD;
				ShootBarrage ();
			}
		}
	}

	void ShootBarrage(){
		for (int i = 0; i < FiresPerBarrage; i++) {
			Invoke ("Shoot", i * GunDelay);		
		}
	}

	void Shoot(){

	}

	void OnTriggerEnter(Collider _col)
	{
		if(_col.gameObject.CompareTag("Player"))
		{
			print ("entered");
			target = _col.gameObject;
		}
	}
}
