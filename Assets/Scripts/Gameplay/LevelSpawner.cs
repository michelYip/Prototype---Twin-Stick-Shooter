using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
	#region Exposed

	[Header("Map Boundary")]
	public int m_spawnBoundaryMinX = -19;
	public int m_spawnBoundaryMaxX =  19;
	public int m_spawnBoundaryMinZ = -8;
	public int m_spawnBoundaryMaxZ =  29;

	[Header("Spawn Distance From Player")]
	[Space(10)]
	public int m_minDistance = 5;

	public void SpawnNewLevel()
	{
		List<Vector3> spawnPositions = new List<Vector3>();
		bool bossFight = false;
		_enemyCount._value = _levelCurrent._value;
		if (_levelCurrent._value % 3 == 2)
		{
			_enemyCount._value++;
			bossFight = true;
		}

		//--> Refacto
		for (int i = 0; i < ((bossFight)? _enemyCount._value-1:_enemyCount._value); i++)
		{
			//Find Random Coordinate
			float dist = float.MinValue;
			Vector3 newPosition = Vector3.zero;
			while(dist < m_minDistance)
			{
				int coordX = Random.Range(m_spawnBoundaryMinX, m_spawnBoundaryMaxX);
				int coordZ = Random.Range(m_spawnBoundaryMinZ, m_spawnBoundaryMaxZ);
				newPosition = new Vector3(coordX, 0.5f, coordZ);
				if (spawnPositions.Contains(newPosition))
					continue;
				else
					spawnPositions.Add(newPosition);
				dist = Vector3.Distance(newPosition, _playerTransform.position);
			}
			
			int randomIndex = Random.Range(0, _enemiesGameObjects.Count);

			Instantiate(_enemiesGameObjects[randomIndex], newPosition, Quaternion.identity, _enemyManagerTransform);	
		}
		if (bossFight)
		{
			//Find Random Coordinate
			float dist = float.MinValue;
			Vector3 newPosition = Vector3.zero;
			while (dist < m_minDistance)
			{
				int coordX = Random.Range(m_spawnBoundaryMinX, m_spawnBoundaryMaxX);
				int coordZ = Random.Range(m_spawnBoundaryMinZ, m_spawnBoundaryMaxZ);
				newPosition = new Vector3(coordX, 0.5f, coordZ);
				if (spawnPositions.Contains(newPosition))
					continue;
				else
					spawnPositions.Add(newPosition);
				dist = Vector3.Distance(newPosition, _playerTransform.position);
			}

			int randomIndex = Random.Range(0, _bossesGameObjects.Count);

			Instantiate(_bossesGameObjects[randomIndex], newPosition, Quaternion.identity, _enemyManagerTransform);
		}
	}

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	#endregion


	#region Private

	private Transform _playerTransform;

	[Header ("Scriptable Objects")]
	[SerializeField] private IntVariable _levelCurrent;
	[SerializeField] private IntVariable _enemyCount;

	[Header ("Enemies And Bosses")]
	[SerializeField] private List<GameObject> _enemiesGameObjects;
	[SerializeField] private List<GameObject> _bossesGameObjects;
	[Space(10)]
	[SerializeField] private Transform _enemyManagerTransform;

	#endregion
}
