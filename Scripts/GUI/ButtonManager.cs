using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Res.Scripts.GUI
{
	public class ButtonManager : MonoBehaviour
	{
		public static ButtonManager Instance;
		public static event Action<ButtonState> OnStateChange;
		public ButtonState State;

		public GameObject MainMenuCanvas;
		public GameObject SettingsCanvas;
		public GameObject InformationCanvas;

		void Awake(){

			Instance = this;
		}

		public void UpdateState(ButtonState newState){

			State = newState;

			switch(newState){

				case ButtonState.StartGame:
						HandleStartGameButton();
					break;
				case ButtonState.Settings:
						HandleSettingsButton();
					break;
				case ButtonState.Information:
						HandleInformationButton();
					break;
				case ButtonState.BackToMenu:
						HandleBackToMenuButton();
					break;
				case ButtonState.ExitGame:
						HandleExitGameButton();
					break;
				default:
					throw new System.Exception(null);
			}

			OnStateChange?.Invoke(newState);
		}

		public void HandleStartGameButton(){
			
			SceneManager.LoadScene(1);
		}

		public void HandleSettingsButton(){
			
			MainMenuCanvas.SetActive(false);
			SettingsCanvas.SetActive(true);
		}

		public void HandleInformationButton(){

			MainMenuCanvas.SetActive(false);
			InformationCanvas.SetActive(true);
		}

		public void HandleBackToMenuButton(){

			MainMenuCanvas.SetActive(true);
			SettingsCanvas.SetActive(false);
			InformationCanvas.SetActive(false);
		}

		public void HandleExitGameButton(){

			Application.Quit();
		}

		public enum ButtonState{

			StartGame,
			Settings,
			Information,
			BackToMenu,
			ExitGame
		}
	}
}