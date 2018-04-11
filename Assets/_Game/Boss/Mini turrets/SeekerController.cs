using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerController : MonoBehaviour {

	public float seekerLifeDuration;
	// Use this for initialization
	void Start () {
		OnSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnSpawn (){
		Invoke("SelfDespawn",seekerLifeDuration);
	}

	void OnDespawn(){
		
	}

	void SelfDespawn(){
		Mangos.PoolManager.Despawn (gameObject);
	}
}
