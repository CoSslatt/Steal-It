using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Camera
{
	public class CameraMode : MonoBehaviour, ICameraModes
	{
		public Transform target;

		private Vector3 offset = new Vector3(35 / 3f, 23 / 1.5f, 0);
		private Vector3 smoothPosition;
		public void NearMode(Transform camTransform){

			// get smoothed position by lerp
            smoothPosition = Vector3.Lerp(
					camTransform.position, 
					target.position + offset,
					0.01f
				);

			camTransform.position = smoothPosition;
        }

		private Vector3 farPosition = new Vector3(34.38938f, 25.34549f);
		public void FarMode(Transform camTransform){

			// trigger camera to the player only in axis z
			Vector3 cameraFarPosition = new Vector3(
				farPosition.x,
				farPosition.y,
				target.position.z
			);

			// make its movement smooth
			Vector3 smoothTransition = Vector3.Lerp(camTransform.position, cameraFarPosition, 0.01f);
			
			camTransform.position = smoothTransition;
		}
	}
}