using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject menuPanel, optionPanel, fade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			Debug.Log ("a click");
		}

	}

	public void PlaySound(int n){
		switch (n) {
		case 0:
			//Play Select Sound
			break;
		case 1:
			//Play click sound
			break;
		default:
			break;
		}
	}

	public void IniciarJuego(){
		SceneManager.LoadScene ("maingame", LoadSceneMode.Single);
	}

	public void OpcionesIn(){
		menuPanel.SetActive (false);
		optionPanel.SetActive (true);
	}

	public void OpcionesOut(){
		menuPanel.SetActive (true);
		optionPanel.SetActive (false);
	}

	public void Credits()
	{
		SceneManager.LoadScene ("WinScene", LoadSceneMode.Single);
	}

	public void Salir(){
		StartCoroutine ("Exit");
	}

	IEnumerator Exit(){
		yield return new WaitForSeconds (1f);
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
