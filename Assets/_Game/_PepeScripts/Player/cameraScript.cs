using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mangos {
public class cameraScript : MonoBehaviour {
		public Transform target;
		[Range(0, 1)]
		public float smoothSpeed = 0.3f;
		public Vector3 offset;
		public RectTransform pntrPos;
		public Camera cam;
	private float camTurnSpeed = 10.0f;
	Vector3 desiredPosition;
	Vector3 smoothedPosition;

		Vector3 camRotation = Vector3.zero;

		void Start(){
			cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();
			pntrPos = GameObject.Find ("Pointer").GetComponent<RectTransform> ();
		}

		void Update() {
			desiredPosition = target.TransformPoint (Vector3.back * 10);
			transform.position = target.position;

			/*desiredPosition = target.position;
			//desiredPosition = target.TransformPoint(Vector3.back * 10);
			smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
			smoothedPosition = (desiredPosition - transform.position) * smoothSpeed * Time.deltaTime;
			transform.Translate(smoothedPosition * 1);
			transform.LookAt (transform.position + smoothedPosition);

			if (pntrPos.localPosition.x <= -920.0f) {
				camRotation.y -= camTurnSpeed;
				Debug.Log("Aaaaaaaa");
			} else if (pntrPos.localPosition.x >= 920.0f) {
				camRotation.y += camTurnSpeed;
				Debug.Log("Bbbbbbbbb");
			}

			if (pntrPos.localPosition.y <= -520.0f) {
				camRotation.x += camTurnSpeed;
				Debug.Log("Cccccccc");
			} else if (pntrPos.localPosition.y >= 440.0f) {
				camRotation.x -= camTurnSpeed;
				Debug.Log("Ddddddd");
			}
			transform.Rotate (camRotation * Time.deltaTime);*/
		}
	}
}
