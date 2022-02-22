using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Res.Scripts.Game
{
	public class GameFinish : MonoBehaviour
	{
		public static GameFinish Instance;

        [SerializeField] private GameObject gameFinishCanvas;

        private void Awake()
        {
            Instance = this;
        }

        public void MainMethod()
        {
            StartCoroutine(ShowCanvas());
        }

        IEnumerator ShowCanvas()
        {
            gameFinishCanvas.SetActive(true);

            yield return new WaitForSeconds(4f);

            SceneManager.LoadScene(0);
        }
	}
}