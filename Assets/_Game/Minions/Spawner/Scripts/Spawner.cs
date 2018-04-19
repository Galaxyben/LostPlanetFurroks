using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class Spawner : MonoBehaviour {
		public Rigidbody EBullet;
		//public Rigidbody BBullet;
		public Rigidbody Minion1;
		public Rigidbody Minion2;
		public int spawnerNumber = 12;
		public GameObject[] selectorArr;
		public GameObject selector;

		private float spawnTimer = 7f;
		float timer = 0f;
		int waveNumber = 0;

		void Start () {

			//selectorArr = new GameObject[spawnerNumber];

			Mangos.PoolManager.PreSpawn (EBullet.gameObject, 5);
			Mangos.PoolManager.SetPoolLimit (EBullet.gameObject, 100);

			/*Mangos.PoolManager.PreSpawn (BBullet.gameObject, 25);
			Mangos.PoolManager.SetPoolLimit (BBullet.gameObject, 300);*/

			Mangos.PoolManager.PreSpawn (Minion1.gameObject, 1);
			Mangos.PoolManager.SetPoolLimit (Minion1.gameObject, 10);

			Mangos.PoolManager.PreSpawn (Minion2.gameObject, 1);
			Mangos.PoolManager.SetPoolLimit (Minion2.gameObject, 5);
		}
		

		void Update () {
			timer += Time.deltaTime;
			if(timer >= spawnTimer)
			{
				DoSpawn ();
			}
		}

		public void DoSpawn()
		{
			switch(waveNumber)
			{
			case 0:
				for(int i = 0; i <= 11; i++)
				{
					Instantiate (Minion1.gameObject, selectorArr[i].gameObject.transform.position, Quaternion.identity);
				}
				break;
			case 1:
				for(int i = 0; i < 12; i++)
				{
					Instantiate (Minion2.gameObject, selectorArr[i].gameObject.transform.position, Quaternion.identity);
				}
				break;
			default:
				waveNumber = 0;
				break;
			}
			++waveNumber;
			timer = 0f;

			spawnTimer = Random.Range(7f, 10f);
		}
	}
}