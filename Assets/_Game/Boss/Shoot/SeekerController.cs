using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SeekerController : MonoBehaviour {

	public float seekerLifeDuration;
	public float Velocidad;
	public AnimationCurve SeekerForce;
	public AnimationCurve StartingForce;
	float t = 0;
	public Transform objective;

	Rigidbody rigi;
	// Use this for initialization
	void Start () {
		OnSpawn ();
		rigi = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigi.velocity = Vector3.up * StartingForce.Evaluate (t) * Time.deltaTime * Velocidad + (objective.position - transform.position) / (objective.position - transform.position).magnitude * SeekerForce.Evaluate (t) * Time.deltaTime * Velocidad;
		transform.LookAt (transform.position + rigi.velocity.normalized);
		t += Time.deltaTime / 3f;
	}

	public void OnSpawn (){
		Invoke("SelfDespawn",seekerLifeDuration);
	}

	void OnDespawn(){
		SelfDespawn ();
	}

	void SelfDespawn(){
		Debug.Log ("Crash");
		gameObject.SetActive (false);
		//Mangos.PoolManager.Despawn (gameObject);
	}
}
