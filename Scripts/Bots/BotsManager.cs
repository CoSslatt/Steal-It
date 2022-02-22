using Res.Scripts.Game;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Bots
{
	public class BotsManager : MonoBehaviour
	{
		public static BotsManager Instance;

        public static event Action<BotsState> OnStateChange;

        public BotsState State;

        private void Awake()
        {
            if (Instance == this) 
                Destroy(gameObject);

            else
                Instance = this;
        }

        public void UpdateState(BotsState newState, Transform trigger)
        {
            State = newState;

            switch (newState)
            {
                case BotsState.Detection:
                    HandleGameOver(trigger);
                    break;
                default:
                    throw new Exception(null);
            }

            OnStateChange?.Invoke(newState);
        }

        private void HandleGameOver(Transform trigger)
        {
            GameOver.Instance.MainMethod(trigger);
        }

		public enum BotsState
        {
            Detection
        }
    }
}