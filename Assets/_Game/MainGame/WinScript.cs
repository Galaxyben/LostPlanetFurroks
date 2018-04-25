using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

	public class WinScript : MonoBehaviour {
		public Image fade;
		float t;

		// Use this for initialization
		void Start () {
			Invoke ("toMainMenu", 10f);
		}

		// Update is called once per frame
		void Update () {
			t += Time.deltaTime;
			fade.color = Color.Lerp(new Color (0, 0, 0, 1), new Color (0, 0, 0, 0), t);
		}

		void toMainMenu(){
			SceneManager.LoadScene ("MainMenuScene");
		}
	}
