using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Gold
{
	public class GoldSpawnPoints : MonoBehaviour
	{
		public static GoldSpawnPoints Instance;
		public List<Transform> spawnPoint = new List<Transform>();

		void Awake()
		{
			Instance = this;
		}
	}
}