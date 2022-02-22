using System;
using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Game
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;

		public static event Action<GameObject, GameObject> OnGoldSpawning;

		public GameObject goldPrefab;
		public GameObject goldPrefabParent;

		void Start(){

			DontDestroyOnLoad(gameObject);
		}

		void Awake(){
			
			if (Instance == this)
				Destroy(gameObject);
			else
				Instance = this;
		}

		public void HandleGoldSpawning(){

			OnGoldSpawning?.Invoke(goldPrefab, goldPrefabParent);
		}
	}
}