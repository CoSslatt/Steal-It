using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot7
{
	public class Bot7Detection : MonoBehaviour
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
			if (Physics.CheckSphere(transform.position + new Vector3(0, 2f), 5f, player) ||
				Physics.CheckSphere(transform.position + new Vector3(-5f, 2f, 3f), 3f, player))
			{
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;

			Gizmos.DrawWireSphere(transform.position + new Vector3(0, 2f), 5f);
			Gizmos.DrawWireSphere(transform.position + new Vector3(-5f, 2f, 3f), 3f);
		}
	}
}