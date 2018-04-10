using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{
	public GameObject bulletPrefab;
	public float FireRate;

	void Start () {		
		Mangos.PoolManager.PreSpawn (bulletPrefab, 500);
		Mangos.PoolManager.SetPoolLimit (bulletPrefab, 1500);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
