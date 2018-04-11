using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCenter : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject seekerPrefab;
	public float FireRate;
	public float updateDirTime;
	public float Vel;
	float ogUpdateDirTime;
	Vector3 goingTo;
	public Transform objective;

	void Start () {		
		Mangos.PoolManager.PreSpawn (bulletPrefab, 500);
		Mangos.PoolManager.SetPoolLimit (bulletPrefab, 1500);
		Mangos.PoolManager.PreSpawn (seekerPrefab, 20);
		Mangos.PoolManager.SetPoolLimit (seekerPrefab, 100);
		goingTo = objective.transform.position;
		ogUpdateDirTime = updateDirTime;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(){
		gameObject.transform.Translate (0f, (objective.transform.position.y-gameObject.transform.position.y)*0.7f*Time.deltaTime , 0f);
		GetComponent<Rigidbody>().AddForce (((goingTo - gameObject.transform.position)/(goingTo - gameObject.transform.position).magnitude)*Time.deltaTime * Vel);
		updateDirTime -= Time.deltaTime;

		if (updateDirTime <= 0) {
			updateDirTime = ogUpdateDirTime;
			UpdateGoingTo ();
		}

	}

	public void UpdateGoingTo(){
		goingTo = objective.transform.position;
		Debug.Log ("updated goiung to");
	}
}
