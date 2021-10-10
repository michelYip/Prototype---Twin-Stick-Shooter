using UnityEngine;

public class PlayerFire : MonoBehaviour
{
	#region Exposed

	[Header("Shooting Property")]
	public int m_rateOfFire = 5;

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_cannon = transform.Find("Cannon");
	}

	private void Update()
    {
		_delayBetweenBullet = 1f / m_rateOfFire;
        if (Input.GetAxisRaw("Fire") > 0 && Time.time > _nextBullet)
		{
			FireBullet();
			_nextBullet = Time.time + _delayBetweenBullet;
		}
    }

	#endregion


	#region Private

	private float _delayBetweenBullet;
	private float _nextBullet;

	[SerializeField] private float _bulletSpeed = 15f;
	[Space(10)]
	[SerializeField] GameObject _bulletPrefab;
	private Transform _cannon;

	private void FireBullet()
	{
		GameObject BulletsList = GameObject.Find("BulletsList");
		GameObject bullet = Instantiate(_bulletPrefab, _cannon.position, _cannon.rotation, BulletsList.transform);
		BulletControl bulletControl = bullet.GetComponent<BulletControl>();
		bulletControl.Shoot(_bulletSpeed);
	}

    #endregion
}