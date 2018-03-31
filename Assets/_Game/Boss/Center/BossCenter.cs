using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mangos.PoolManager.PreSpawn (GetComponentInChildren<BossMiniTurret>().bullet, 20);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
