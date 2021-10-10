using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	#region Exposed


	#endregion


	#region UnityAPI

	private void Awake()
	{
		_enemyCount._value = GameObject.FindGameObjectsWithTag("Enemy").Length;
		_enemyCount._value += GameObject.FindGameObjectsWithTag("Boss").Length;
	}


	#endregion


	#region Private

	[SerializeField] private IntVariable _enemyCount;

	#endregion
}
