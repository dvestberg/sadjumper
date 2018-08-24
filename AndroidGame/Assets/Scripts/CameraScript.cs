using UnityEngine;

namespace Assets.Scripts
{
	public class CameraScript : MonoBehaviour
	{
		private SpawnManager _spawnManager;

		void Start()
		{
			_spawnManager = FindObjectOfType<SpawnManager>();
		}

		void LateUpdate()
		{
			var posititon = _spawnManager.GetPlayerPosition();
			var vector = Vector3.Lerp(transform.position, posititon, Time.deltaTime * 100);
			transform.position = new Vector3(vector.x, vector.y, -10);
			transform.LookAt(posititon);
		}
	}
}
