using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claws : MonoBehaviour {

	public GameObject claw;
	public ParticleSystem laserMamon;
	public float StartupTime;
	public float FiringTime;
	[Range(0, 1)]
	public float RotationVel;
	public Transform objective;
	Vector3 lookingAt;
	bool isStartingLasser;
	bool fireAhead;
	public float t;
	bool vulnerable = true;
	public float invulnerableTime;
	public float HP;
	public bool isAlive = true;
	float t2;
	bool fadeAway;
	Material mat;
	public GameObject explosionParent;
	// Use this for initialization
	void Start () {
		claw.transform.LookAt (transform.position + Vector3.forward);
		lookingAt = Vector3.forward;
		mat = claw.GetComponentInChildren<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.L))
			startFireLasser ();
		if (isStartingLasser) {
			
			if (fireAhead) {
				lookingAt -= (lookingAt - (objective.position + objective.gameObject.GetComponent<Rigidbody> ().velocity)) * 0.97f * Time.deltaTime;
				claw.transform.LookAt (lookingAt);
			} else {
				lookingAt -= (lookingAt - objective.position) * 0.6f * Time.deltaTime;
				claw.transform.LookAt (lookingAt);
			}
		}
		
		if (fadeAway)
		{
			t2 += Time.deltaTime/2f;
			mat.color = Color.Lerp(Color.white, new Color (1, 1, 1, 0), t2);
		}

	}

	public void startFireLasser()
	{
		if (GetComponentInParent<BossController> ().firingLasser == false) {
			StartCoroutine ("FireLasser");
			laserMamon.Play();
			t = 0;
		}
	}

	IEnumerator FireLasser()
	{
		lookingAt = transform.position + lookingAt;
		isStartingLasser = true;
		GetComponentInParent<BossController> ().firingLasser = true;
		yield return new WaitForSeconds (StartupTime - StartupTime*0.2f);
		if (GetComponentInParent<BossController> ().level >= 3) {
			fireAhead = true;
		}
		yield return new WaitForSeconds (0.2f * StartupTime);
		fireAhead = false;
		//fire
		isStartingLasser = false;
		yield return new WaitForSeconds(FiringTime);
		GetComponentInParent<BossController> ().firingLasser = false;
		lookingAt = -transform.position + lookingAt;
	}

	public void GetDamaged(){
		print("claw damaged");
		if (vulnerable && isAlive) {
			StartCoroutine ("DamageStop");
			HP -= 1;
		}
	}

	IEnumerator DamageStop(){
		vulnerable = false;
		claw.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.white);
		float startTime = Time.time;

		while (Time.time < startTime +invulnerableTime) 
		{
			claw.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.Lerp(Color.white, Color.black, Mathf.InverseLerp(startTime, startTime+invulnerableTime, Time.time) ));
			Mangos.StaticManager.soundManager.ESounds (4);
			yield return null;
		}
			
		claw.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.black);
		vulnerable = true;
	}

	public void Die(){
		StartCoroutine("Explode");
		mat.SetFloat("_Mode", 2); 
		fadeAway = true;
	}


	IEnumerator Explode(){
		for(int i = 0; i < explosionParent.GetComponentsInChildren<ParticleSystem>().Length; i++)
		{
			explosionParent.GetComponentsInChildren<ParticleSystem>()[i].Play();
			yield return new WaitForSeconds(0.5f);
		}
		yield return new WaitForSeconds (0.2f);
		for(int i = 0; i < explosionParent.GetComponentsInChildren<ParticleSystem>().Length; i++)
		{
			explosionParent.GetComponentsInChildren<ParticleSystem>()[i].Stop();
		}
		mat.SetFloat("_Mode", 0); 
	}

}
