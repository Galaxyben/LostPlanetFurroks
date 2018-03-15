using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject menuPanel, optionPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IniciarJuego(){
		//SceneManager.LoadScene ("Game", LoadSceneMode.Single);
	}

	public void OpcionesIn(){
		menuPanel.SetActive (false);
		optionPanel.SetActive (true);
	}

	public void OpcionesOut(){
		menuPanel.SetActive (true);
		optionPanel.SetActive (false);
	}

	public void Salir(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Salir();
		#endif
	}
}
