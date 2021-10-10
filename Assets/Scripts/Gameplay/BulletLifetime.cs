using UnityEngine;

public class BulletLifetime : MonoBehaviour
{
	#region Exposed

	public float m_lifeTime = 10f;

	#endregion


	#region UnityAPI

	private void Awake()
	{
		Destroy(gameObject, m_lifeTime);
	}

	#endregion


	#region Private

	#endregion
}

