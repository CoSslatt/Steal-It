using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot10
{
	public class Bot10Detection : MonoBehaviour
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
			if (Physics.CheckSphere(transform.position + new Vector3(0, 2f), 6f, player))
			{
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;

			Gizmos.DrawWireSphere(transform.position + new Vector3(0, 2f), 6f);
		}
	}
}