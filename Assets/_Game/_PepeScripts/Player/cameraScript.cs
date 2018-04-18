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

		void Start(){
			cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			pntrPos = GameObject.Find ("Pointer").GetComponent<RectTransform> ();
		}

		void Update() {
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;

			if (pntrPos.position.x <= -920.0f) {
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
			}
		}

		public void camRotation(){

		}
	}
}
