using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float bulletLifeDuration = 5.0f;
	//Nuevo Start
	public void OnSpawn()
	{
		//Si esta vivo o algo, poner el isAlive = true y la vida a 100;
		Invoke("SelfDespawn",bulletLifeDuration);
	}

	//Nuevo on destroy
	public void OnDespawn()
	{
		CancelInvoke ();
		//Si tiene fisicas, aqui poner el RigidBody.velocity = Vector3.zero;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	void SelfDespawn ()
	{
		Mangos.PoolManager.Despawn (gameObject);
		OnDespawn ();
	}

	void Start () 
	{
		OnSpawn ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision _col)
	{
		SelfDespawn ();
		OnDespawn ();
	}

}
