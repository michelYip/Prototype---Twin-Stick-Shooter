using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
	#region Exposed


	#endregion


	#region UnityAPI

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if(gameObject.tag == "EnemyBullet")
			{
				_playerStats.isHit();
				Destroy(gameObject);
			}
		}
		else
		{
			if (other.gameObject.CompareTag("Bullet"))
			{
				int destructible = LayerMask.NameToLayer("EnemyBulletDestructible");
				int indestructible = LayerMask.NameToLayer("EnemyBulletIndestructible");
				switch (LayerMask.LayerToName(gameObject.layer))
				{
					case "EnemyBulletDestructible":
						Destroy(other.gameObject);
						Destroy(gameObject);
						break;
					case "EnemyBulletIndestructible":
						Destroy(other.gameObject);
						break;
					default:
						break;
				}
			}
		}
	}

	#endregion


	#region Private

	//[SerializeField] private IntVariable _playerCurrentHP;
	[SerializeField] private PlayerStats _playerStats;

	#endregion
}