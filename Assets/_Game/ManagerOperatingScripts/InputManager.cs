using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class InputManager : MonoBehaviour {

		KeyCode A = KeyCode.K, X = KeyCode.I, B = KeyCode.J, Y = KeyCode.U;

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
