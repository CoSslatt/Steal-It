using System.Collections.Generic;
using Res.Scripts.Game;
using UnityEngine;

namespace Res.Scripts.Audio
{
	public class MenuMusicManager : MonoBehaviour
	{
		private AudioSource audioSrc;
		private SettingsManager settingsManager;

		void Start(){

			audioSrc = GetComponent<AudioSource>();
			settingsManager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
		}

		void Update(){

			audioSrc.volume = settingsManager.MenuMusicVolume;
		}
	}
}