using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naveMovement : MonoBehaviour {
	Rigidbody rigi;
	public Camera Cam;
	public GameObject piv_;
	public float playerVel;
	public float playerSpeed;
	public float turnSpeed;
	public float acceleration;

	public float amplitude;
	public float frequency;

	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	bool T_Active;
	bool setT = false;
	float holdTime;

	void Start () {
		rigi = GetComponent <Rigidbody> ();
		posOffset = transform.position;
	}

	void Update () {
///----------------------------------------------------------------------------------------------

		tempPos = posOffset;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
		transform.position = tempPos;

///----------------------------------------------------------------------------------------------
	}

	public void Jump()
	{

	}

	public void Shoot()
	{

	}
}
