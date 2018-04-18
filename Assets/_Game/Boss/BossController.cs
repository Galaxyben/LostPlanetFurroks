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
		pinzas = GetComponent<Claws> ();
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
		
		if(pinzas.HP <= 0 && pinzas.isAlive)
			ClawDies();
		if(anillo.HP <= 0 && anillo.isAlive)
			RingDies();
		if(centro.HP <= 0 && centro.isAlive)
			CenterDies();

		print(anillo.HP);

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
		case "Claw":
			pinzas.GetDamaged();
			break;
		case "Ring":
			anillo.GetDamaged();
			break;
		case "Center":
			if(!anillo.isAlive)
				centro.GetDamaged();
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
		anillo.Die ();
		anillo.isAlive = false;
	}

	void KillRing(){
		anillo.ringRigi.gameObject.SetActive(false);
	}
	
	void ClawDies(){
		Invoke("KillClaw", 2f);
		pinzas.isAlive = false;
	}
	
	void KillClaw(){
		pinzas.claw.SetActive(false);
	}
	
	void CenterDies(){
		Invoke("KillCenter", 2f);
		centro.isAlive = false;
		Invoke("KillClaw", 2f);
		pinzas.isAlive = false;
	}
	
	void KillCenter(){
		centro.gameObject.SetActive(false);
	}
}
