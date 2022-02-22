using System;
using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot5
{
	public class Bot5DetectionScript : MonoBehaviour
	{
		[SerializeField] private LayerMask player;

        private void Start()
        {
			BotsManager.OnStateChange += BotsManager_OnStateChange;
        }

        private void OnDestroy()
        {
			BotsManager.OnStateChange -= BotsManager_OnStateChange;
		}

        private void BotsManager_OnStateChange(BotsManager.BotsState state)
        {
			state = BotsManager.BotsState.Detection;
        }

        void Update()
		{
			if (Physics.CheckSphere(transform.position + new Vector3(0, 2f, -2f), 3.5f, player))
            {
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
            }

			if (Physics.Linecast(
					transform.position + new Vector3(0, 3f, 0), 
					transform.position + new Vector3(0, 3f, -16f),
					player
				)
			)
            {
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}
		}

        private void OnDrawGizmosSelected()
        {
			Gizmos.color = Color.red;
			Gizmos.DrawLine(
				transform.position + new Vector3(0, 3f, 0), 
				transform.position + new Vector3(0, 3f, -16f)
			);
			Gizmos.DrawWireSphere(
				transform.position + new Vector3(0, 2f, -2f)
				, 3.5f
			);
        }
    }
}