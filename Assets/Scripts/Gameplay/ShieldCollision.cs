using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bullet"))
		{
			Destroy(other.gameObject);
		}

	}

	#endregion


	#region Private

	#endregion
}