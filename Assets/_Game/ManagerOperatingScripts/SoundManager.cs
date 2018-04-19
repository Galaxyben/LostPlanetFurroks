using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
	public class SoundManager : MonoBehaviour {
		static public AudioSource AS;
		static public AudioClip laserBasic;
		static public AudioClip laserBazooka;
		static public AudioClip laserDualGun;
		static public AudioClip ELaser1;
		static public AudioClip ELaser2;
		static public AudioClip ELaser3;
		static public AudioClip BossBasicMisil;
		static public AudioClip BossPrepRay;
		static public AudioClip BossMegaRay;
		static public AudioClip pickUpSound;
		static public AudioClip hit1;
		static public AudioClip playerAlert;

		void Start () {
			AS = GetComponent<AudioSource> ();
		}

		void Awake(){
			StaticManager.soundManager = this;
		}

		public void playerSounds(int soundSelect)
		{
			switch(soundSelect)
			{
			case 1:
				AS.PlayOneShot (laserBasic);
				break;
			case 2:
				AS.PlayOneShot (laserBazooka);
				break;
			case 3:
				AS.PlayOneShot (laserDualGun);
				break;
			default:
				AS.PlayOneShot (laserBasic);
				break;
			}
		}

		public void ESounds(int soundSelect)
		{
			switch(soundSelect)
			{
			case 1:
				AS.PlayOneShot (ELaser1);
				break;
			case 2:
				AS.PlayOneShot (ELaser2);
				break;
			case 3:
				AS.PlayOneShot (ELaser3);
				break;
			default:
				AS.PlayOneShot (ELaser1);
				break;
			}
		}

		public void BSounds(int soundSelect)
		{
			switch(soundSelect)
			{
			case 1:
				AS.PlayOneShot (BossBasicMisil);
				break;
			case 2:
				AS.PlayOneShot (BossPrepRay);
				break;
			case 3:
				AS.PlayOneShot (BossMegaRay);
				break;
			default:
				AS.PlayOneShot (BossBasicMisil);
				break;
			}
		}

		public void generalSounds(int soundSelect)
		{
			switch (soundSelect) {
			case 1:
				AS.PlayOneShot (hit1);
				break;
			case 2:
				AS.PlayOneShot (pickUpSound);
				break;
			case 3:
				//AS.Play (playerAlert);
				break;
			default:
				AS.PlayOneShot (hit1);
				break;
			}
		}
	}
}
