using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos {
public class cameraScript : MonoBehaviour {
		public Transform target;
		public float smoothSpeed = 0.3f;
		public Vector3 offset;
		public RectTransform pntrPos;
		public Camera cam;
	private float camTurnSpeed = 10.0f;
	Vector3 desiredPosition;
	Vector3 smoothedPosition;

		void Start(){
			cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			pntrPos = GameObject.Find ("Pointer").GetComponent<RectTransform> ();
		}

		void Update() {
			desiredPosition = target.position + offset;
			//smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			smoothedPosition = (desiredPosition - transform.position) * 0.9f * Time.deltaTime;
			transform.Translate(smoothedPosition * 1);
			transform.LookAt (transform.position + smoothedPosition);
			print(smoothedPosition);

			/*if (pntrPos.position.x <= -920.0f) {
				Quaternion camRotation = cam.transform.rotation;
				camRotation.y -= camTurnSpeed;
			} else if (pntrPos.position.x >= 920.0f) {
				Quaternion camRotation = cam.transform.rotation;
				camRotation.y += camTurnSpeed;
			}

			if (pntrPos.position.y <= -520.0f) {
				Quaternion camRotation = cam.transform.rotation;
				camRotation.x += camTurnSpeed;
			} else if (pntrPos.position.y >= 440.0f) {
				Quaternion camRotation = cam.transform.rotation;
				camRotation.x -= camTurnSpeed;
			}*/
		}

		public void camRotation(){

		}
	}
}
