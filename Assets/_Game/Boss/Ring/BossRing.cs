using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRing : MonoBehaviour {

	Rigidbody rigi;
	public float RotationSpeed;
	public float RotationAccel;
	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		rigi.AddTorque (0.0f, RotationSpeed, 0.0f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			FireAll ();

		if (Input.GetKeyDown (KeyCode.S))
			FireStar ();

		if (rigi.angularVelocity.magnitude <= RotationSpeed) {
			rigi.AddTorque (0.0f, RotationAccel, 0.0f, ForceMode.Acceleration);
		} else if (rigi.angularVelocity.magnitude > 0) {
			rigi.AddTorque (0.0f, -RotationAccel, 0.0f, ForceMode.Acceleration);
		}
	}

	public void FireAll(){ 
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			arr [i].Fire ();
		}
			
	}
	public void FireStar(){
		float intervals = 1f / (rigi.angularVelocity.magnitude*10);
		for (int i = 0; i < 100; i++) {
			Invoke ("FireAll", i * intervals);
		}
	}
}
