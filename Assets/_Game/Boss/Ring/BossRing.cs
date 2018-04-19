using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRing : MonoBehaviour {

	public Rigidbody ringRigi;
	public Rigidbody centerRigi;
	Material mat;
	public float RotationSpeed;
	public float RotationAccel;
	public float angDragMag;
	public float FirePower;
	public float BarrageDelay;
	public int BarrageRounds;
	public Transform objective;
	Vector3 goingTo;
	Vector3 lookinAt;
	Transform generalDirection;
	public float Vel;
	public float HP;
	public bool isAlive = true;
	public float invulerableTime;
	bool vulnerable = true, fadeAway;
	float t;
	public GameObject explosionParent;
	// Use this for initialization
	void Start () {
		lookinAt = objective.position;
		generalDirection = GameObject.Find ("RingParent").transform;
		goingTo = objective.transform.position;
		centerRigi = GetComponent<Rigidbody> ();
		mat = ringRigi.gameObject.GetComponentInChildren<MeshRenderer>().material;
		//rigi.AddTorque (0.0f, RotationSpeed, 0.0f, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown (KeyCode.A))
			FireAll ();

		if (Input.GetKeyDown (KeyCode.S))
			FireStar ();

		if (Input.GetKey (KeyCode.L))
			FireLine ();

		if(Input.GetKeyDown (KeyCode.B))
			FireBarrage();

		if (Input.GetKeyDown (KeyCode.DownArrow))
			RotationSpeed -= 1;

		if (Input.GetKeyDown (KeyCode.UpArrow))
			RotationSpeed += 1;

		if (Input.GetKeyDown (KeyCode.D))
			GetDamaged ();
		*/
		
		if(Input.GetKeyDown(KeyCode.X)){
			StartCoroutine("Explode");
		}
		angDragMag = ringRigi.angularVelocity.magnitude;

		ringRigi.gameObject.transform.position = gameObject.transform.position;
		
		if (fadeAway)
		{
			t += Time.deltaTime/2f;
			mat.color = Color.Lerp(Color.white, new Color (1, 1, 1, 0), t);
		}
	}
		
	

	public void Rotate(){
		if (ringRigi.angularVelocity.magnitude < RotationSpeed && ringRigi.angularVelocity.magnitude >= 0) {
			ringRigi.AddTorque (Vector3.up * RotationAccel * Time.deltaTime, ForceMode.Force);
		} else if (ringRigi.angularVelocity.magnitude >= 0 && ringRigi.angularVelocity.magnitude > RotationSpeed) {
			ringRigi.AddTorque (0.0f, -RotationAccel * Time.deltaTime, 0.0f, ForceMode.Force);
		}
	}

	public void FireAll(){ 
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			arr [i].Fire (FirePower);
		}
			
	}

	public void FireOne(char grup, int id){
		BossMiniTurret[] arr = GetComponentsInChildren<BossMiniTurret> ();
		for (int i = 0; i < arr.Length; i++) {
			if(arr[i].id == id && arr[i].Group == grup)
				arr [i].Fire (FirePower);
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
				arr [i].Fire (FirePower);
			}
		}
	}

	public void FireBarrage(){
		StartCoroutine ("fireBarrageCoroutine");
	}

	IEnumerator fireStarCoroutine(int ite){
		for (int i = 0; i < ite; i++) {
			FireOne ('a', 3);
			FireOne ('b', 3);
			FireOne ('c', 3);
			FireOne ('d', 3);
			yield return new WaitForSeconds (0.09f/ringRigi.angularVelocity.magnitude);
		}
	}

	IEnumerator fireBarrageCoroutine(){
		for(int i = 0; i < BarrageRounds; i++)
		{
			FireAll ();
			yield return new WaitForSeconds(BarrageDelay);
		}
	}

	public void GetDamaged()
	{
		if (vulnerable && isAlive) {
			StartCoroutine ("damageStop");
			HP -= 1.0f;
		}
	}

	IEnumerator damageStop(){
		vulnerable = false;
		Vector3 temp = ringRigi.angularVelocity; 
		ringRigi.angularVelocity = Vector3.zero;
		ringRigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.white);
		float startTime = Time.time;

		while (Time.time < startTime +invulerableTime) 
		{
			ringRigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.Lerp(Color.white, Color.black, Mathf.InverseLerp(startTime, startTime+invulerableTime, Time.time) ));
			yield return null;
		}

		ringRigi.angularVelocity = temp;
		ringRigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.black);
		vulnerable = true;
	}

	public void Die(){
		RotationSpeed = 1;
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
	}
}
