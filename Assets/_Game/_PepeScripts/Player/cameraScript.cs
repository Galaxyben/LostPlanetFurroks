using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos {
public class cameraScript : MonoBehaviour {
		public Transform target;
		public float smoothSpeed = 0.125f;
		public Vector3 offset;
		public RectTransform pntrPos;
		public Camera cam;
		private float camTurnSpeed = 10.0f;

		void Start(){
			//pntrPos = GameObject.Find ("Pointer").GetComponent<RectTransform> ();
		}

		void FixedUpdate() {
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			transform.position = smoothedPosition;
		}

		public void camRotation(){

			/*if (pntrPos.position.x <= -920.0f) {
				
			} else if (pntrPos.position.x >= 920.0f) {
				
			}

			if (pntrPos.position.y <= -520.0f) {
				
			} else if (pntrPos.position.y >= 440.0f) {
				
			}*/
		}
	}
}
