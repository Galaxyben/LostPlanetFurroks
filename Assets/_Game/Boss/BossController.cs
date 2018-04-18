using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public float[] FireAllDelay;
	public float[] FireStarDelay;
	public float[] FireBarrageDelay;
	public float[] FireSeekersDelay;
	public float[] FireLaserDelay;
	float[] ogFAll;
	float[] ogFStar;
	float[] ogFBarrage;
	float[] ogFSeeker;
	float[] ogFLaser;
	public int level = 0;
	BossCenter centro;
	BossRing anillo;
	Claws pinzas;
	public bool firingLasser;

	// Use this for initialization
	void Start () {
		centro = GetComponent<BossCenter> ();
		anillo = GetComponent<BossRing> ();
		ogFAll = new float[FireAllDelay.Length];
		ogFStar = new float[FireStarDelay.Length];
		ogFBarrage = new float[FireBarrageDelay.Length];
		ogFSeeker = new float[FireSeekersDelay.Length];
		ogFLaser = new float[FireLaserDelay.Length];
		for (int i = 0; i < FireAllDelay.Length; i++) {
			ogFAll [i] = FireAllDelay [i];
			ogFBarrage [i] = FireBarrageDelay [i];
			ogFSeeker [i] = FireSeekersDelay [i];
			ogFStar [i] = FireStarDelay [i];
			ogFLaser [i] = FireLaserDelay [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		centro.Move (firingLasser);
		anillo.Rotate ();
		if (!firingLasser) {
			FireAllCountDown (level);
			FireStarCountDown (level);
			FireBarrageCountDown (level);
			FireSeekerCountDown (level);
			FireLaserCountDown (level);
		}

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

	public void OnBulletHit(string _tag){
		switch(_tag){
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
		if (FireStarDelay [lvl] <= 0) {
			anillo.FireStar ();
			FireStarDelay[lvl] = ogFStar[lvl];
		}
	}

	void FireBarrageCountDown(int lvl){
		FireBarrageDelay [lvl] -= Time.deltaTime;
		if (FireBarrageDelay [lvl] <= 0) {
			anillo.FireBarrage ();
			FireBarrageDelay[lvl] = ogFBarrage[lvl];
		}
	}

	void FireSeekerCountDown(int lvl){
		FireSeekersDelay [lvl] -= Time.deltaTime;
		if (FireSeekersDelay [lvl] <= 0) {
			centro.FireSeekers ();
			FireSeekersDelay[lvl] = ogFSeeker[lvl];
		}
	}

	void FireLaserCountDown(int lvl){
		FireLaserDelay [lvl] -= Time.deltaTime;
		if (FireLaserDelay [lvl] <= 0) {
			FireLaserDelay [lvl] = ogFLaser [lvl];
			pinzas.startFireLasser ();
		}
	}
	
	void RingDies(){
		Invoke("KillRing", 2f);
	}
	
	void KillRing(){
		anillo.gameObject.SetActive(false);
	}
	
	void ClawDies(){
		Invoke("KillClaw", 2f);
	}
	
	void KillClaw(){
		pinzas.gameObject.SetActive(false);
	}
	
	void CenterDies(){
		Invoke("KillCenter", 2f);
	}
	
	void KillCenter(){
		centro.gameObject.SetActive(false);
	}
}
