using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
	#region Exposed
	#endregion


	#region UnityAPI

	private void OnCollisionEnter(Collision collision)
	{
		GameObject obj = collision.gameObject;
		if (obj.CompareTag("Player"))
		{
			_playerCurrentStats.isHit();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bullet"))
		{
			switch (gameObject.tag)
			{
				case "Enemy":
					gameObject.SetActive(false);
					_currentTimeLeft._value += _bonusTimeOnKill;
					_enemyCount._value--;
					Destroy(other.gameObject);
					Destroy(gameObject, _destroyTimer);
					break;

				case "Boss":
					if (_enemyCount._value == 1)
					{
						gameObject.SetActive(false);
						_enemyCount._value--;
						Destroy(other.gameObject);
						Destroy(gameObject, _destroyTimer);
					}
					break;
				default:
					break;
			}
		}
		
	}

	#endregion


	#region Private

	//[SerializeField] private IntVariable _playerCurrentHP;
	[SerializeField] private PlayerStats _playerCurrentStats;
	[SerializeField] private IntVariable _enemyCount;
	[Space(20)]
	[SerializeField] private float _bonusTimeOnKill = 5f;
	[SerializeField] private FloatVariable _currentTimeLeft;

	private float _destroyTimer = 1f;


	#endregion
}
