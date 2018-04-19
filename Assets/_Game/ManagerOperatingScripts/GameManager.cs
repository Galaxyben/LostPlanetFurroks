using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mangos {
	public class GameManager : MonoBehaviour {
		public Mangos.GameState gameState = GameState.mainMenu;
		void Awake(){
			StaticManager.gameManager = this;
		}
	
	
		void Update(){
			if(Mangos.StaticManager.playerShip.life <= 0)
			{
				StartCoroutine("GameOver");	
			}
		}
		
		IEnumerator GameOver(){
			yield return new WaitForSeconds (2f);
			SceneManager.LoadScene ("GameOver");
		}
	}
}
