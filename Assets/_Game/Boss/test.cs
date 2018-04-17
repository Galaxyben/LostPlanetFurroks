using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	float t;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		GetComponent<Rigidbody> ().velocity = (150 * Vector3.right * Mathf.Cos(t));
	}
}
