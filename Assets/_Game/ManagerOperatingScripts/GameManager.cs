using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mangos {
	public class GameManager : MonoBehaviour {
		public Mangos.GameState gameState = GameState.mainMenu;
		public BossController bosses;
		void Awake(){
			StaticManager.gameManager = this;
		}
	
	
		void Update(){
			if(Mangos.StaticManager.playerShip.life <= 0)
			{
				Invoke("GameOver", 3f);	
			}
			if(!bosses.gameObject.activeSelf)
			{
				Invoke("GameOver", 3f);
			}
		}
		
		void GameOver(){
			SceneManager.LoadScene ("GameOver");
		}
	}
}
