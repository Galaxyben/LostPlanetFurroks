using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mangos {
	public class gameOverScript : MonoBehaviour {



		public void GetToMenu()
		{
			Mangos.GameState gameState = GameState.mainMenu;
			SceneManager.LoadScene ("Main Menu");
		}

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
