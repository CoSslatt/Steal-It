using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.GUI
{
	public class Information : MonoBehaviour
	{
		void Start()
		{
			ButtonManager.OnStateChange += ButtonManager_OnStateChange;
		}

		void OnDestroy(){

			ButtonManager.OnStateChange -= ButtonManager_OnStateChange;
		}

        private void ButtonManager_OnStateChange(ButtonManager.ButtonState state){
            
			state = ButtonManager.ButtonState.Information;
        }

		public void OnClick(){

			ButtonManager.Instance.UpdateState(ButtonManager.ButtonState.Information);
		}
	}
}