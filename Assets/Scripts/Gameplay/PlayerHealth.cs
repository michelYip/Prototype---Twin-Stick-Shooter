using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_playerCurrentStats._healthValue = _playerStartStats._healthValue;
		_playerCurrentStats._invincibility = _playerStartStats._invincibility;
		_playerCurrentStats._invincibilityTime = _playerStartStats._invincibilityTime;
		_playerCurrentStats._isHit = _playerStartStats._isHit;
	}

	private void Update()
	{
		_playerCurrentStats.checkInvincibility();
		if (_playerCurrentStats._healthValue <= 0)
		{
			gameObject.SetActive(false);
			Destroy(gameObject, _destroyTimer);
		}
	}

	#endregion


	#region Private

	[SerializeField] private PlayerStats _playerStartStats;
	[SerializeField] private PlayerStats _playerCurrentStats;

	private float _destroyTimer = 2f;

	#endregion
}
