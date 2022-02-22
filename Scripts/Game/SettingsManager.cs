using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Res.Scripts.Game
{
	public class SettingsManager : MonoBehaviour
	{
		[SerializeField] private GameObject farKeyInputField;
		[SerializeField] private GameObject nearKeyInputField;
		[SerializeField] private Toggle CameraModesOnScrollToggle;
		[SerializeField] private Slider menuMusicSlider;
		[SerializeField] private Slider gameMusicSlider;
		public string KeyForFarMode {get; set;}
		public string KeyForNearMode {get; set;}
		public bool CameraModeOnScroll {get; set;}
		private string defaultKeyForFarMode = "j";
		private string defaultKeyForNearMode = "l";
		public float MenuMusicVolume {get; set;}
		public float GameMusicVolume {get; set;}

		void Start(){

			DontDestroyOnLoad(gameObject);
		}

		void Update(){

			try
			{
				Scene currentScene = SceneManager.GetActiveScene();

				string near = nearKeyInputField.GetComponent<InputField>().text;
				string far = farKeyInputField.GetComponent<InputField>().text;

				// make sure that we don't override desired variable with null variables
				if (far != "" && near != ""){

					KeyForFarMode = far;
					KeyForNearMode = near;
				}
				else if (far != "" && near == ""){

					KeyForFarMode = far;
					KeyForNearMode = defaultKeyForNearMode;
				}
				else if (far == "" && near != ""){

					KeyForFarMode = defaultKeyForFarMode;
					KeyForNearMode = near;
				}
				else if (far == "" && near == ""){

					KeyForFarMode = defaultKeyForFarMode;
					KeyForNearMode = defaultKeyForNearMode;
				}

				bool cameraOnScrool = CameraModesOnScrollToggle.isOn;
				CameraModeOnScroll = cameraOnScrool;

				float menuMusicValue = menuMusicSlider.value;
				float gameMusicValue = gameMusicSlider.value;

				MenuMusicVolume = menuMusicValue;
				GameMusicVolume = gameMusicValue;
			}
			catch
			{
					
			}
		}
	}
}