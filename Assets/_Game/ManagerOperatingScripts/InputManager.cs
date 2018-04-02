using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class InputManager : MonoBehaviour {
		/// Manager Operating Scripts
		KeyCode A = KeyCode.K, X = KeyCode.I, B = KeyCode.J, Y = KeyCode.U;
		float JS_h = Input.GetAxis("Horizontal");
		float JS_v = Input.GetAxis("Vertical");

		//ForceMode.

		void Awake(){
			StaticManager.inputManager = this;
		}

		void Update(){
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
