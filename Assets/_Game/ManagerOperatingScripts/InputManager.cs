using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class InputManager : MonoBehaviour {

		KeyCode A = KeyCode.K, X = KeyCode.I, B = KeyCode.J, Y = KeyCode.U;

		//Para borrarse por algo mejor despues:
		GameObject obj;

		void Awake(){
			StaticManager.inputManager = this;
			Debug.Log ("Awake");
		}

		void Start(){
			obj = GameObject.Find ("BossCenter");
			Debug.Log ("Start");
		}
			
		void Update(){
			Debug.Log ("a");
			if (Input.GetKeyDown (KeyCode.A)) {
				obj.GetComponentInChildren<BossRing> ().FireAll ();
				Debug.Log ("a");
			}

			switch (StaticManager.gameManager.gameState) {

			case GameState.mainMenu:
				if (Input.GetKeyDown (B)) {
					///Tell menu to back the fuck up
				}
				break;

			case GameState.mainGame:

				break;

			case GameState.pause:
				break;

			default:
				break;
			}
		}
	}
}
