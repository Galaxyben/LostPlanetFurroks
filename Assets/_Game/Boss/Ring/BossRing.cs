using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRing : MonoBehaviour {

	public Rigidbody rigi;
	public float RotationSpeed;
	public float RotationAccel;
	public float angDragMag;
	public Transform objective;
	Vector3 lookinAt;
	Transform generalDirection;
	// Use this for initialization
	void Start () {
		lookinAt = objective.position;
		generalDirection = GameObject.Find ("RingParent").transform;
		//rigi.AddTorque (0.0f, RotationSpeed, 0.0f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
			FireAll ();

		if (Input.GetKeyDown (KeyCode.S))
			FireStar ();

		if (Input.GetKey (KeyCode.L))
			FireLine ();

		if (Input.GetKeyDown (KeyCode.DownArrow))
			RotationSpeed -= 1;

		if (Input.GetKeyDown (KeyCode.UpArrow))
			RotationSpeed += 1;

		if (rigi.angularVelocity.magnitude <= RotationSpeed && rigi.angularVelocity.magnitude > 0) {
			rigi.AddTorque (Mathf.Sin(generalDirection.up.x) * RotationAccel, Mathf.Cos(generalDirection.up.y) * RotationAccel, Mathf.Sin(generalDirection.up.z) * RotationAccel);
		} else if (rigi.angularVelocity.magnitude >= 0) {
			rigi.AddTorque (0.0f, -RotationAccel, 0.0f);
		}
			
		lookinAt += ((objective.position - lookinAt) * 0.6f * Time.deltaTime);

		generalDirection.LookAt (lookinAt); 

		angDragMag = rigi.angularVelocity.magnitude;
	}

	public void FireAll(){ 
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			arr [i].Fire (5f);
		}
			
	}

	public void FireOne(char grup, int id){
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			if(arr[i].id == id && arr[i].Group == grup)
				arr [i].Fire (5f);
		}
	}

	public void FireStar(){
		StartCoroutine (fireStarCoroutine (10));
	}

	public void FireLine(){
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		Transform center = GetComponentInParent<BossCenter> ().transform;
		for (int i = 0; i < arr.Length; i++) {
			if ((arr [i].gameObject.transform.position - center.position).x < 1.2 && (arr [i].gameObject.transform.position - center.position).x > 0.8f) {
				arr [i].Fire (5f);
			}
		}
	}

	IEnumerator fireStarCoroutine(int ite){
		for (int i = 0; i < ite; i++) {
			FireOne ('a', 3);
			FireOne ('b', 3);
			FireOne ('c', 3);
			FireOne ('d', 3);
			yield return new WaitForSeconds (0.09f/rigi.angularVelocity.magnitude);
		}
	}
}
