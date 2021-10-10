using UnityEngine;

public class ShieldManager : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void Update()
	{
		if (_enemyCount._value <= 1)
		{
			Destroy(gameObject);
		}
	}

	#endregion


	#region Private

	[SerializeField] IntVariable _enemyCount;



	#endregion
}