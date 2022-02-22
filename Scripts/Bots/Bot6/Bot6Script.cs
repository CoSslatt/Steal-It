using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace Res.Scripts.Bots.Bot6
{
	public class Bot6Script : MonoBehaviour
	{
		[SerializeField] private Animator animator;
		[SerializeField] private List<Transform> endPositions = new List<Transform>();
		private NavMeshAgent agent;

		private int destinationIndex = 1;

		void Start()
		{

			animator = GetComponent<Animator>();
			agent = GetComponent<NavMeshAgent>();

			agent.SetDestination(endPositions[1].position);

			animator.Play("Walking");
		}

		void Update()
		{
			GoToThePoint();
		}

		private void GoToThePoint()
		{
			if (agent.remainingDistance == 0f)
			{
				if (destinationIndex < 1)
				{

					destinationIndex++;

					StartCoroutine(ToIdleCoroutine());
				}
				else
				{

					destinationIndex--;

					StartCoroutine(ToIdleCoroutine());
				}
			}
		}

		IEnumerator ToIdleCoroutine()
		{
			animator.Play("Idle");

			yield return new WaitForSeconds(4f);

			agent.SetDestination(endPositions[destinationIndex].position);

			animator.Play("Walking");
		}
	}
}