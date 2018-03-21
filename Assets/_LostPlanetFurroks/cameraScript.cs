using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class cameraScript : MonoBehaviour {

	Rigidbody rigi;
	public float Pawah;
	public float MaxSpeed;
	public float RotationPawah;
	public float RotationMaxSpeed;
	[Range(0.0f, 1.0f)]
	public float RotationBreaks;
	[Range(0.0f, 1.0f)]
	public float Frenos;
	public float turnSensibility;
	[SerializeField]
	float dir; //-1 -> 100% izquierda, 1 -> 100% derecha
	//TurbinaR
	float RT_Force = 0; // Right Translation Force
	float RR_Force = 0; //Right Rotation Force
	public KeyCode RT_Forward;   	//Tecla configurable para avanzar
	public KeyCode RT_Backguard;	//y para retroceder (la turbina)
	//TurbinaL
	float LT_Force = 0; //Left Translation Force
	float LR_Force = 0; //Left Rotation Force
	public KeyCode LT_Forward;
	public KeyCode LT_Backguard;
	public Vector3 test;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		RT_Forward = KeyCode.E;
		LT_Forward = KeyCode.Q;
		RT_Backguard = KeyCode.D;
		LT_Backguard = KeyCode.A;
		RotationPawah = 3;
		RotationMaxSpeed = 2;
		MaxSpeed = 30;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (RT_Forward)) {
			RT_Force = 1;

		} else if (Input.GetKey (RT_Backguard)) {
			RT_Force = -1;
		} else {
			RT_Force = 0;
		}
		if (Input.GetKey (LT_Forward)) {
			LT_Force = -1;
		} else if (Input.GetKey (LT_Backguard)) {
			LT_Force = 1;
		} else {
			LT_Force = 0;
		}

		dir += (RT_Force + LT_Force) * turnSensibility * Time.deltaTime;

		if (RT_Force + LT_Force == 0)
			dir = 0;

		if (dir <= -1)
			dir = -1;

		if (dir >= 1)
			dir = 1;


		if (rigi.velocity.magnitude < MaxSpeed) {
			rigi.velocity += gameObject.transform.forward * ((RT_Force - LT_Force) * (Mathf.Abs(RT_Force - LT_Force) == 2 ? 0.5f : 1 )) * Pawah;
		}
		//gameObject.transform.Rotate (Vector3.up * (LT_Force + RT_Force) * RotationSpeed);
		if (rigi.angularVelocity.magnitude < RotationMaxSpeed) {
			rigi.angularVelocity += gameObject.transform.up * (dir) * RotationPawah;
		}

		//Friccion del aire ...?
		rigi.velocity -= Frenos*rigi.velocity;
		if (rigi.velocity.magnitude < 0)
			rigi.velocity = Vector3.zero;

		test = rigi.angularVelocity;
		rigi.angularVelocity -= RotationBreaks*rigi.angularVelocity;
		if (rigi.angularVelocity.magnitude <= 0) {
			rigi.angularVelocity = Vector3.zero;
		}


	}
}