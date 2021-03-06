﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public enum GameState {
		mainMenu,
		mainGame,
		pause,
	}

	public enum AppState {
		running,
		loading
	}

	public class StaticManager {
		public static AppManager appManager;
		public static InputManager inputManager;
		public static GameManager gameManager;
		public static AudioManager audioManager;
	}
}