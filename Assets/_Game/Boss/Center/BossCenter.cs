using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject seekerPrefab;
	public Transform misilSpawn1;
	public Transform misilSpawn2;
	public float FireRate;
	public float updateDirTime;
	public float Vel;
	public float SeekerLaunchForce;
	float ogUpdateDirTime;
	Vector3 goingTo;
	public Transform objective;
	Rigidbody rigi;
	bool vulnerable;
	public float invulnerableTime;
	public float HP;
	public bool isAlive = true;

	void Start () {		
		Mangos.PoolManager.PreSpawn (bulletPrefab, 500);
		Mangos.PoolManager.SetPoolLimit (bulletPrefab, 1500);
		Mangos.PoolManager.PreSpawn (seekerPrefab, 20);
		Mangos.PoolManager.SetPoolLimit (seekerPrefab, 100);
		goingTo = objective.transform.position;
		ogUpdateDirTime = updateDirTime;
		rigi = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E))
			FireSeekers ();
	}

	public void Move(bool _f){
		if (_f) {
			rigi.velocity -= rigi.velocity * Time.deltaTime/GetComponent<Claws>().StartupTime;
		} else {
			gameObject.transform.Translate (0f, (objective.transform.position.y - gameObject.transform.position.y) * 0.7f * Time.deltaTime, 0f);
			rigi.AddForce (((goingTo - gameObject.transform.position) / (goingTo - gameObject.transform.position).magnitude) * Time.deltaTime * Vel);
			updateDirTime -= Time.deltaTime;
		}
		if (updateDirTime <= 0) {
			updateDirTime = ogUpdateDirTime;
			UpdateGoingTo ();
		}

	}

	public void UpdateGoingTo(){
		goingTo = objective.transform.position;
		//Debug.Log ("updated goiung to");
	}

	public void FireSeekers(){
		ActuallyFireSeekers ();
		Invoke ("ActuallyFireSeekers", 0.2f);
		Invoke ("ActuallyFireSeekers", 0.4f);
	}

	public void ActuallyFireSeekers()
	{
		//Left seeker
		Transform go = Mangos.PoolManager.Spawn (seekerPrefab, misilSpawn1.position, Quaternion.identity);
		go.gameObject.GetComponent<SeekerController>().OnSpawn ();
		go.gameObject.GetComponent<SeekerController> ().objective = objective;
		//Right Seeker
		Transform go2 = Mangos.PoolManager.Spawn (seekerPrefab, misilSpawn2.position, Quaternion.identity);
		go2.gameObject.GetComponent<SeekerController>().OnSpawn ();
		go2.gameObject.GetComponent<SeekerController> ().objective = objective;
	}

	public void GetDamaged(){
		if (vulnerable && isAlive) {
			StartCoroutine ("DamageStop");
		}
	}

	IEnumerator DamageStop(){
		vulnerable = false;
		Vector3 temp = rigi.velocity; 
		rigi.velocity = Vector3.zero;
		rigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.white);
		float startTime = Time.time;

		while (Time.time < startTime +invulnerableTime) 
		{
			rigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.Lerp(Color.white, Color.black, Mathf.InverseLerp(startTime, startTime+invulnerableTime, Time.time) ));
			yield return null;
		}

		rigi.velocity = temp;
		rigi.gameObject.GetComponentInChildren<MeshRenderer> ().material.SetColor("_EmissionColor", Color.black);
		vulnerable = true;
	}
}
