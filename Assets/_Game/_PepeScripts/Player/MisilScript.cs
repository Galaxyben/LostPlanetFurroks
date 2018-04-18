using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilScript : MonoBehaviour {

	internal Transform target;
	private float rocketTurnSpeed;
	private float rocketSpeed;
	private float randomOffset;

	private float timerSinceLaunch_Contor;
	private float objectLifeTimerValue;

	// Use this for initialization
	void Start () 
	{
		OnSpawn();
		rocketTurnSpeed = 50.0f;
		rocketSpeed = 45f;
		randomOffset = 0.0f;

		timerSinceLaunch_Contor = 0;
		objectLifeTimerValue = 10;
	}

	// Update is called once per frame
	void Update ()
	{
		timerSinceLaunch_Contor += Time.deltaTime;

		if (target != null) {
			if (timerSinceLaunch_Contor > 1) {
				if ((target.position - transform.position).magnitude > 50) {
					randomOffset = 100.0f;
					rocketTurnSpeed = 90.0f;
				} else {
					randomOffset = 5f;
					//if close to target
					if ((target.position - transform.position).magnitude < 10) {
						rocketTurnSpeed = 180.0f;
					}
				}
			}

			Vector3 direction = target.position - transform.position + Random.insideUnitSphere * randomOffset;
			direction.Normalize ();
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (direction), rocketTurnSpeed * Time.deltaTime);
			transform.Translate (Vector3.forward * rocketSpeed * Time.deltaTime);
		}
	}
	
	void OnCollisionEnter(Collision _col){
		if(_col.gameObject.CompareTag("Claw") || _col.gameObject.CompareTag("Ring") || _col.gameObject.CompareTag("Center")){
			_col.gameObject.GetComponent<BossController>().OnBulletHit(_col.gameObject.tag);
		}
		OnDespawn();
		Mangos.PoolManager.Despawn (gameObject);
	}
	
	void OnSpawn(){
		Invoke("SelfDespawn",objectLifeTimerValue);
	}
	
	void SelfDespawn(){
		Mangos.PoolManager.Despawn (gameObject);
		OnDespawn();
	}
	
	void OnDespawn(){
		CancelInvoke ();
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}
}
