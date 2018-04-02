using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{
	public GameObject bulletPrefab;


	void Start () {		
		Mangos.PoolManager.PreSpawn (bulletPrefab, 40);
		Mangos.PoolManager.SetPoolLimit (bulletPrefab, 500);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
