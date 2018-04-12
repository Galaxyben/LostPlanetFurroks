using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public float[] FireAllDelay;
	public float[] FireStarDelay;
	public float[] FireBarrageDelay;
	public float[] FireSeekersDelay;
	float[] ogFAll;
	float[] ogFStar;
	float[] ogFBarrage;
	float[] ogFSeeker;
	public int level = 0;
	BossCenter centro;
	BossRing anillo;

	// Use this for initialization
	void Start () {
		centro = GetComponent<BossCenter> ();
		anillo = GetComponent<BossRing> ();
		ogFAll = FireAllDelay;
		ogFStar = FireStarDelay;
		ogFBarrage = FireBarrageDelay;
		ogFSeeker = FireSeekersDelay;
	}
	
	// Update is called once per frame
	void Update () {
		centro.Move ();
		anillo.Rotate ();
		FireAllCountDown (level);
		FireStarCountDown (level);
		FireBarrageCountDown (level);
		FireSeekerCountDown (level);

		switch (level) {
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		default:
			break;
		}
	}

	void FireAllCountDown(int lvl){
		FireAllDelay [lvl] -= Time.deltaTime;
		if (FireAllDelay [lvl] <= 0) {
			FireAllDelay [lvl] = ogFAll [lvl];
			anillo.FireAll ();
		}
	}

	void FireStarCountDown(int lvl){
		FireStarDelay [lvl] -= Time.deltaTime;
		if (FireAllDelay [lvl] <= 0) {
			anillo.FireStar ();
			FireStarDelay = ogFStar;
		}
	}

	void FireBarrageCountDown(int lvl){
		FireBarrageDelay [lvl] -= Time.deltaTime;
		if (FireBarrageDelay [lvl] <= 0) {
			anillo.FireBarrage ();
			FireBarrageDelay = ogFBarrage;
		}
	}

	void FireSeekerCountDown(int lvl){
		FireSeekersDelay [lvl] -= Time.deltaTime;
		if (FireSeekersDelay [lvl] <= 0) {
			anillo.FireSeekers ();
			FireBarrageDelay = ogFSeeker;
		}
	}
}
