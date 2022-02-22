using System.Collections.Generic;
using Res.Scripts.Game;
using UnityEngine;

namespace Res.Scripts.Camera
{
	public class CameraManager : MonoBehaviour
	{
		[SerializeField] private CameraMode cmMode;
		private SettingsManager settingsManager;
		private bool isActiveFarMode;
		private bool isActiveNearMode;
		private float mouseScrollWheel;

		void Start(){

			isActiveNearMode = true;

			settingsManager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
		}

		void Update(){

			MyInputs();

            try
            {
				ChangeCameraModeWithKeys();
				ChangeCameraModeWithScroll();
            }
            catch
            {
				cmMode.target = GameOver.Instance.trigger;
            }
		}

		private void MyInputs(){

			mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
		}

		private void ChangeCameraModeWithKeys(){

			if (Input.GetKeyDown(settingsManager.KeyForFarMode)){

				isActiveFarMode = true;
				isActiveNearMode = false;	
			}

			if (Input.GetKeyDown(settingsManager.KeyForNearMode)){

				isActiveFarMode = false;
				isActiveNearMode = true;
			}

			if (isActiveFarMode) cmMode.FarMode(gameObject.transform);
			else if (isActiveNearMode) cmMode.NearMode(gameObject.transform);
		}

		private void ChangeCameraModeWithScroll(){

			if (mouseScrollWheel > 0f && settingsManager.CameraModeOnScroll){ // forward

				isActiveFarMode = false;
				isActiveNearMode = true;
			}
			else if (mouseScrollWheel < 0f && settingsManager.CameraModeOnScroll){ // backwards

				isActiveFarMode = true;
				isActiveNearMode = false;
			}
		}
	}
}