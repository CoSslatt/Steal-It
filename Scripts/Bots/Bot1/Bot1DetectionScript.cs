using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots.Bot1
{
	public class Bot1DetectionScript : MonoBehaviour
	{
		[SerializeField] private GameObject point;
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
            if (Physics.CheckSphere(transform.position + new Vector3(1f, 2f, 0), 4f, player))
            {
                BotsManager.Instance.UpdateState(BotsManager.BotsState.Detection, gameObject.transform);
            }

            if (Physics.Linecast(
                    transform.position + new Vector3(0, 2f, 0),
                    point.transform.position,
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
				transform.position + new Vector3(0, 2f, 0),
				point.transform.position
			);

			Gizmos.DrawWireSphere(transform.position + new Vector3(1f, 2f, 0), 4f);
        }
    }
}