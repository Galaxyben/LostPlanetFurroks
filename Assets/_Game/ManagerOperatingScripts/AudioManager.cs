using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {	
	public class AudioManager : MonoBehaviour {

		public float volumeSFX = 1;
		public float volumeMusic = 1;
		public float MasterVolume = 1;

		void Awake(){
			StaticManager.audioManager = this;
		}
			
	}
}
