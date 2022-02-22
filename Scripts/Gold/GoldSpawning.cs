using System.Collections.Generic;
using Res.Scripts.Game;
using UnityEngine;

namespace Res.Scripts.Gold
{
	public class GoldSpawning : MonoBehaviour
	{
		int stacksCount = 0;

		void Start()
		{
			GameManager.OnGoldSpawning += GameManager_OnGoldSpawning;

			while (stacksCount < 8){

				GameManager.Instance.HandleGoldSpawning();
				stacksCount++;
			}
		}

		void OnDestroy(){

			GameManager.OnGoldSpawning -= GameManager_OnGoldSpawning;
		}

        private void GameManager_OnGoldSpawning(GameObject prefab, GameObject goldPrefabParent)
        {
			// get random number from the gold spawn points list
			int randNumber = Random.Range(0, GoldSpawnPoints.Instance.spawnPoint.Count);

            var newGold = Instantiate(prefab, goldPrefabParent.transform);
			
			// override gold position by randomized one then make sure the position won't be repeated
			newGold.transform.position = GoldSpawnPoints.Instance.spawnPoint[randNumber].position;
			GoldSpawnPoints.Instance.spawnPoint.RemoveAt(randNumber);

			newGold.AddComponent<GoldScript>();
        }
	}
}