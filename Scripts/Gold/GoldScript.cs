using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Res.Scripts.Gold
{
	public class GoldScript : MonoBehaviour
	{
		private LayerMask playerLayer;

		private AudioSource coinSound;

		void Start()
        {
            playerLayer = LayerMask.GetMask("Player");
			coinSound = GameObject.Find("coin1").GetComponent<AudioSource>();
        }

        void Update()
		{
			if (Physics.CheckSphere(transform.position, 2f, playerLayer))
            {
				GoldCount.Instance.AddGold();
				coinSound.Play();

				Destroy(gameObject);
            }
		}

        private void OnDrawGizmosSelected()
        {
			Gizmos.color = Color.yellow;

			Gizmos.DrawWireSphere(transform.position, 2f);
        }
    }
}