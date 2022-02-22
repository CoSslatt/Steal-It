using System;
using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.GUI
{
	public class StartGame : MonoBehaviour
	{
		void Start(){

			ButtonManager.OnStateChange += ButtonManager_OnStateChange;
		}

		void OnDestroy(){

			ButtonManager.OnStateChange -= ButtonManager_OnStateChange;
		}

        private void ButtonManager_OnStateChange(ButtonManager.ButtonState state)
        {
			state = ButtonManager.ButtonState.StartGame;
        }

		public void OnClick(){

			ButtonManager.Instance.UpdateState(ButtonManager.ButtonState.StartGame);
		}
    }
}