using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Res.Scripts.GUI
{
	public class ExitGame : MonoBehaviour
	{
		void Start()
		{
			ButtonManager.OnStateChange += ButtonManager_OnStateChange;
		}

		void OnDestroy(){

			ButtonManager.OnStateChange -= ButtonManager_OnStateChange;
		}

        private void ButtonManager_OnStateChange(ButtonManager.ButtonState state){
            
			state = ButtonManager.ButtonState.ExitGame;
        }

		public void OnClick(){

			ButtonManager.Instance.UpdateState(ButtonManager.ButtonState.ExitGame);
		}
    }
}