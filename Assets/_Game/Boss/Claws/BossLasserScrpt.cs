using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mangos{
public class BossLasserScrpt : MonoBehaviour {

	BossController boss;
	// Use this for initialization
	void Start () {
		boss = GetComponentInParent<BossController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay(Collider _col)
	{
		print("en laser2");
		if(_col.CompareTag("Player") && boss.firingLasser)
		{
			_col.GetComponent<NaveScript>().life -= Time.deltaTime * 10.0f;
		}
	}
			
}
}