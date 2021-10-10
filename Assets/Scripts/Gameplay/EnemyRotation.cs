using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
	#region Exposed


	#endregion


	#region UnityAPI

	private void Update()
	{
		transform.Rotate(new Vector3(0, _rotationSpeed * Time.deltaTime, 0));
	}

	#endregion


	#region Private

	[SerializeField] private float _rotationSpeed = 25f;

	#endregion
}

