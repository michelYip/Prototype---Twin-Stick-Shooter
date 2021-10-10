using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void Start()
	{
		_playerHPText	= transform.Find("PlayerHP").GetComponent<TextMeshProUGUI>();
		_enemyCountText = transform.Find("EnemyCount").GetComponent<TextMeshProUGUI>();
		_timerText	= transform.Find("TimeLeft").GetComponent<TextMeshProUGUI>();
		_currentLevelText = transform.Find("CurrentLevel").GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		_playerHPText.SetText("Player Health : " + _playerCurrentStats._healthValue);
		_enemyCountText.SetText("Enemy Count : " + _enemyCount._value);
		_timerText.SetText((_timerStart._value - (Time.time - _timerCurrent._value)).ToString("0.00"));
		_currentLevelText.SetText(_currentLevel._value.ToString());
	}

	#endregion


	#region Private

	//[SerializeField] private IntVariable _playerCurrentHP;
	[SerializeField] private PlayerStats _playerCurrentStats;
	[SerializeField] private IntVariable _enemyCount;
	[SerializeField] private FloatVariable _timerCurrent;
	[SerializeField] private FloatVariable _timerStart;
	[SerializeField] private IntVariable _currentLevel;

	private TextMeshProUGUI _playerHPText;
	private TextMeshProUGUI _enemyCountText;
	private TextMeshProUGUI _timerText;
	//private float _startTime;
	private TextMeshProUGUI _currentLevelText;

	#endregion
}
