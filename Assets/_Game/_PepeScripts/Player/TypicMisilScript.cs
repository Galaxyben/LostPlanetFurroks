using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypicMisilScript : MonoBehaviour {
	public float bulletLifeDuration = 5.0f;

	public void OnSpawn()
	{
		//Si está vivo o algo, poner el isAlive = true y la vida a 100;
		Invoke("SelfDespawn", bulletLifeDuration);
	}

	public void OnDespawn()
	{
		CancelInvoke ();
		//Si tiene fisicas, aqui poner el rigidbody.velocity = vector3.zero;
	}

	void SelfDespawn()
	{
		Mangos.PoolManager.Despawn (gameObject);
	}

	void Start () {
		OnSpawn ();
	}

	void Update () {
		
	}

	void OnCollisionEnter (Collision _col)
	{
		SelfDespawn ();
		OnDespawn ();
	}
}
