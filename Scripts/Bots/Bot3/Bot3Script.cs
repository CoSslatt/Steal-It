using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Res.Scripts.Bots.Bot3
{
	public class Bot3Script : MonoBehaviour
	{
		private Animator animator;
		private NavMeshAgent agent;

		[SerializeField] private List<Transform> destinations = new List<Transform>();
		private int destinationIndex = 0; 

		void Start()
		{

            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            agent.SetDestination(destinations[0].position);

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

            agent.SetDestination(destinations[destinationIndex].position);

            animator.Play("Walking");
        }
    }
}
