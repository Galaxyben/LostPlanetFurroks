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
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	void SelfDespawn()
	{
		Mangos.PoolManager.Despawn (gameObject);
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	void Start () {
		OnSpawn ();
	}

	void Update () {
		
	}

	void OnTriggerEnter (Collider _col)
	{
		if(_col.gameObject.CompareTag("Claw") || _col.gameObject.CompareTag("Ring") || _col.gameObject.CompareTag("Center")){
			_col.gameObject.GetComponentInParent<BossController>().OnBulletHit(_col.gameObject.tag);
		}
		Mangos.PoolManager.Despawn (gameObject);
		OnDespawn ();
	}
}
