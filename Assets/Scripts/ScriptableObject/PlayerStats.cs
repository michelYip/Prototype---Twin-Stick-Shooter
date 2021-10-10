using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
	#region Exposed

	public int		_healthValue;
	public bool		_invincibility;
	public float    _invincibilityTime;
	public float	_isHit;

	public void isHit()
	{
		if (!_invincibility)
		{
			_healthValue--;
			_invincibility = true;
			_isHit = Time.time + _invincibilityTime;
		}
	}

	public void checkInvincibility()
	{
		if (_invincibility && Time.time > _isHit)
		{
			_invincibility = false;
		}
	}

	#endregion


	#region UnityAPI

	#endregion


	#region Private

	#endregion
}
