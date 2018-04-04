using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRing : MonoBehaviour {

	public Rigidbody rigi;
	public float RotationSpeed;
	public float RotationAccel;
	// Use this for initialization
	void Start () {
		//rigi.AddTorque (0.0f, RotationSpeed, 0.0f, ForceMode.Impulse);
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

	public void FireOne(char grup, int id){
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			if(arr[i].id == id && arr[i].Group == grup)
				arr [i].Fire ();
		}
	}

	public void FireStar(){
		StartCoroutine (fireStarCoroutine (10));
	}

	IEnumerator fireStarCoroutine(int ite){
		for (int i = 0; i < ite; i++) {
			FireOne ('a', 3);
			FireOne ('b', 3);
			FireOne ('c', 3);
			FireOne ('d', 3);
			yield return new WaitForSeconds (0.1f);
		}
	}
}
