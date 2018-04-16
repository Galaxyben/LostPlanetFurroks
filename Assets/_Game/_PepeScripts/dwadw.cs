using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwadw : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.WorldToScreenPoint (target.position);
		Debug.Log (Camera.main.WorldToScreenPoint (target.position));
	}
}
