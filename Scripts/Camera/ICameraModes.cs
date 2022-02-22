using UnityEngine;

namespace Res.Scripts.Camera
{
	public interface ICameraModes
	{
		public void FarMode(Transform camTransform);
		public void NearMode(Transform camTransform);
	}
}