using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Res.Scripts.Gold
{
	public class GoldCount : MonoBehaviour
	{
		public static GoldCount Instance;

		[SerializeField] private Text goldCountText;
		[SerializeField] private Text goldCountForFinishScreen;
		private float goldAmount;

        private void Awake()
        {
			if (Instance == this)
				Destroy(gameObject);
			else
				Instance = this;
        }

        void Update()
		{
			goldCountText.text = goldAmount.ToString();
			goldCountForFinishScreen.text = "stolen gold: " + goldAmount;
		}

		public void AddGold()
        {
			goldAmount += 1;
        }
	}
}