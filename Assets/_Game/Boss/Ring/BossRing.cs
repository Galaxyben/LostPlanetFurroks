using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRing : MonoBehaviour {

	Rigidbody rigi;
	public float startingRotationPower;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		rigi.AddTorque (0.0f, startingRotationPower, 0.0f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			FireAll ();
	}

	public void FireAll(){ 
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			arr [i].Fire ();
		}
		
	}
}
