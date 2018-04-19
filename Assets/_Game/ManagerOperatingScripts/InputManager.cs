using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class InputManager : MonoBehaviour {
		/// Manager Operating Scripts
			KeyCode A = KeyCode.K, X = KeyCode.I, B = KeyCode.J, Y = KeyCode.U;

		//ForceMode.

		//Para borrarse por algo mejor despues:
		GameObject obj;

		void Awake(){
			StaticManager.inputManager = this;
		}

		void Start(){
			obj = GameObject.Find ("BossCenter");
		}
			
		void Update(){
			switch (StaticManager.gameManager.gameState) {
			case GameState.mainMenu:
				if (Input.GetKeyDown (B)) {
					///Tell menu to back the fuck up
				}
				break;

			case GameState.mainGame:

				///--------SECCION MOVIMIENTO Y DISPARO PERSONAJE PRINCIPAL---------------
				float Movement_H = Input.GetAxis ("Horizontal");
				float Movement_V = Input.GetAxis ("Vertical");
				if ((Input.GetKeyDown (KeyCode.Q)) || (Input.GetKeyDown (KeyCode.JoystickButton2))) {
					StaticManager.playerShip.Dash (Movement_H, Movement_V);
				}
				StaticManager.playerShip.Movement (Movement_H, Movement_V);
				if (Input.GetButtonDown ("Fire1")) {
					StaticManager.playerShip.Shoot ();
				}
				if ((Input.GetKeyDown (KeyCode.JoystickButton3)) || (Input.GetKeyDown (KeyCode.E))) {
					StaticManager.playerShip.gunType += 1;
				}
				///--------SECCION DE MOVIMIENTO DE CAMARA--------------------------------
				float camMovement_H = Input.GetAxis ("camHorizontal");
				//Debug.Log (camMovement_H);
				float camMovement_V = Input.GetAxis ("camVertical");
				//Debug.Log (camMovement_V);
				StaticManager.playerShip.pointerMovement(camMovement_H, camMovement_V);
				break;

			case GameState.pause:
				break;

			default:
				break;
			}
		}
	}
}
