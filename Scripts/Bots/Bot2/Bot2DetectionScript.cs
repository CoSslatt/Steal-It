using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot2
{
	public class Bot2DetectionScript : MonoBehaviour
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
			if (Physics.CheckSphere(transform.position + new Vector3(0, 2f, 0), 2.5f, player))
			{
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}

			if (Physics.Linecast(
					transform.position + new Vector3(0, 3f, 0),
					transform.position + new Vector3(8f, 3f, 3f),
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
				transform.position + new Vector3(8f, 3f, 3f)
			);
			Gizmos.DrawWireSphere(transform.position + new Vector3(0, 2f, 0), 2.5f);
        }
    }
}