using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMinionController : MonoBehaviour {

	GameObject target;
	Rigidbody rigi;
	Vector3 direction;
	public float Velocidad;
	public float TurnSpeed;
	public float HP;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
		direction = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			direction = (target.transform.position - transform.position) * TurnSpeed * Time.deltaTime;
		} else {
			direction = (transform.forward + transform.right / 50);
		}
		transform.LookAt (transform.position + rigi.velocity);
		rigi.velocity = direction.normalized * Velocidad * Time.deltaTime;
		print (rigi.velocity.magnitude);
	}

	void OnTriggerEnter(Collider _col)
	{
		if(_col.gameObject.CompareTag("Player"))
		{
			print ("entered");
			target = _col.gameObject;
		}
	}
}
