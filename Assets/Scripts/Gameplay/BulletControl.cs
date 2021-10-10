using UnityEngine;

public class BulletControl : MonoBehaviour
{
	#region Exposed

	public void Shoot(float speed)
	{
		_bulletSpeed = speed;
	}

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_bulletRigidBody = GetComponent<Rigidbody>();
		_bulletTransform = GetComponent<Transform>();
	}

	private void FixedUpdate()
	{
		Vector3 velocity = _bulletTransform.forward * _bulletSpeed * Time.fixedDeltaTime;
		_bulletRigidBody.MovePosition(_bulletRigidBody.position + velocity);
	}

	#endregion


	#region Private

	private Transform _bulletTransform;
	private Rigidbody _bulletRigidBody;
	private float _bulletSpeed;

	#endregion
}