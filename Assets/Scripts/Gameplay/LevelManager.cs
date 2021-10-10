using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_levelSpawner = GetComponent<LevelSpawner>();
		_timerCurrent._value = Time.time;
		_levelCurrent._value = 1;

		_HUD = GameObject.Find("HUD");
		_endGameMenu = _HUD.transform.Find("EndGameMenu").gameObject;
	}

	private void Update()
	{
		if (_enemyCount._value <= 0)
		{
			_levelCurrent._value++;
			_levelSpawner.SpawnNewLevel();
		}
		if (_levelCurrent._value > _levelFinal._value)
		{
			Win();
		}
		else if (_playerCurrentStats._healthValue <= 0 || Time.time > _timerCurrent._value + _timerStart._value)
		{
			Lose();
		}
	}

	#endregion


	#region Private

	private LevelSpawner _levelSpawner;

	[SerializeField] private IntVariable _levelCurrent;
	[SerializeField] private IntVariable _levelFinal;
	[Space(20)]
	[SerializeField] private IntVariable _enemyCount;
	[SerializeField] private PlayerStats _playerCurrentStats;

	[Space(20)]
	private GameObject _HUD;
	private GameObject _endGameMenu;
	private TextMeshProUGUI _endGameText;

	[Space(20)]
	[SerializeField] FloatVariable _timerStart;
	[SerializeField] FloatVariable _timerCurrent;

	private void Win()
	{
		MenuManager._inGame = false;
		_endGameText = _endGameMenu.GetComponentInChildren<TextMeshProUGUI>();
		_endGameText.SetText("YoU Win !");
		_endGameMenu.SetActive(true);
		Destroy(gameObject);
	}

	private void Lose()
	{
		MenuManager._inGame = false;
		_endGameText = _endGameMenu.GetComponentInChildren<TextMeshProUGUI>();
		_endGameText.SetText("YoU Lost !");
		_endGameMenu.SetActive(true);
		Destroy(gameObject);
	}

	#endregion
}
