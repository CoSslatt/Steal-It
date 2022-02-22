using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Res.Scripts.Game
{
	public class GameOver : MonoBehaviour
    {
        public static GameOver Instance;
        [HideInInspector] public Transform trigger;

        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject _camera;

        private void Awake()
        {
            Instance = this;
        }

        public void MainMethod(Transform trigger)
        {
            Destroy(GameObject.Find("Player"));

            StartCoroutine(CameraGoesToTrigger(trigger));
        }

        private IEnumerator CameraGoesToTrigger(Transform trigger)
        {
            this.trigger = trigger;

            Vector3 temp = Vector3.Lerp(
                _camera.transform.position,
                trigger.position + new Vector3(0, 5f, 0),
                0.007f
            );

            _camera.transform.position = temp;

            yield return new WaitForSeconds(1f);

            StartCoroutine(ShowMessage());
        } 
        private IEnumerator ShowMessage()
        {
            canvas.SetActive(true);

            yield return new WaitForSeconds(4f);

            GoToMenu();
        }

        private void GoToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}