using System.Collections.Generic;
using Res.Scripts.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Res.Scripts.Audio
{
	public class GameMusicManager : MonoBehaviour
	{
		private AudioSource audioSrc;
		private SettingsManager settingsManager;
		private bool musicIsPlaying;

		void Start(){

			audioSrc = GetComponent<AudioSource>();
			settingsManager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();

			DontDestroyOnLoad(gameObject);
		}

		void Update(){

			Scene currentScene = SceneManager.GetActiveScene();
			if (currentScene.name.Equals("MainGame") && !musicIsPlaying){

				audioSrc.Play();
				musicIsPlaying = true;
			}
			else if (currentScene.name.Equals("MainMenu")){

				audioSrc.Stop();
			}

			audioSrc.volume = settingsManager.GameMusicVolume;
		}
	}
}