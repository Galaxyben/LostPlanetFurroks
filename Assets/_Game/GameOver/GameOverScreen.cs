using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	public Image fade;
	float t;
	void Start () {
		Invoke ("toMainMenu", 4f);
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
