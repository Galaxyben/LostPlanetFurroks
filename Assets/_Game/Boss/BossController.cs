using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public float[] FireDelay1;
	public float[] FireDelay2;
	int level = 0;
	BossCenter centro;
	BossRing anillo;

	// Use this for initialization
	void Start () {
		centro = GetComponent<BossCenter> ();
		anillo = GetComponent<BossRing> ();
	}
	
	// Update is called once per frame
	void Update () {
		centro.Move ();
		anillo.Rotate ();
		switch (level) {
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		}
	}
}
