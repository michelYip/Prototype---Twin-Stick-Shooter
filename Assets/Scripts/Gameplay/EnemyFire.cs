using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	#region Exposed

	[Header("Shooting Property")]
	public int m_rateOfFire = 15;

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_altFire = false;
	}

	private void Update()
	{
		_delayBetweenBullet = 1f / m_rateOfFire;
		if (Time.time > _nextBullet)
		{
			FireBullet(_altFire);
			_nextBullet = Time.time + _delayBetweenBullet;
			_altFire = !_altFire;
		}
	}

	#endregion


	#region Private

	private float _delayBetweenBullet;
	private float _nextBullet;
	private bool _altFire;

	[SerializeField] private float _bulletSpeed = 5f;
	[Space(10)]
	[SerializeField] private List<Transform> _cannons;
	[Space(10)]
	[SerializeField] GameObject _bulletPrefab;
	[SerializeField] GameObject _bulletPrefabIndestructible;

	private void FireBullet(bool altFire)
	{
		GameObject bullet = (altFire) ? _bulletPrefab : _bulletPrefabIndestructible;
		GameObject BulletsList = GameObject.Find("BulletsList");

		foreach(Transform cannon in _cannons)
		{
			Instantiate(bullet, cannon.position, cannon.rotation, BulletsList.transform)
						.GetComponent<BulletControl>()
						.Shoot(_bulletSpeed);
		}
	}

	#endregion
}
