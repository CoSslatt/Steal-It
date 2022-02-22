using System.Collections.Generic;
using UnityEngine;

namespace Res.Scripts.Camera.MenuCamera
{
	public class MenuCameraRotation : MonoBehaviour
	{
		[SerializeField] private float rotationSpeed;

		void Update(){

			transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
		}
	}
}