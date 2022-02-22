using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.GUI
{
	public class Settings : MonoBehaviour
	{
		void Start()
		{
			ButtonManager.OnStateChange += ButtonManager_OnStateChange;
		}

		void OnDestroy(){

			ButtonManager.OnStateChange -= ButtonManager_OnStateChange;
		}

        private void ButtonManager_OnStateChange(ButtonManager.ButtonState state){
            
			state = ButtonManager.ButtonState.Settings;
        }

		public void OnClick(){

			ButtonManager.Instance.UpdateState(ButtonManager.ButtonState.Settings);
		}
	}
}