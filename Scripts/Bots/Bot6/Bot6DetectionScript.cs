using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot6
{
	public class Bot6DetectionScript : MonoBehaviour
	{
		[SerializeField] private Transform point;
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
			if (Physics.CheckSphere(transform.position + new Vector3(0, 2f), 3f, player))
			{
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}

			if (Physics.Linecast(transform.position + new Vector3(0, 2f), point.position, player))
            {
				BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
			}
		}

		private void OnDrawGizmosSelected()
        {
			Gizmos.color = Color.red;

			Gizmos.DrawLine(transform.position + new Vector3(0, 2f), point.position);
			Gizmos.DrawWireSphere(transform.position + new Vector3(0, 2f), 3f);
        }
    }
}