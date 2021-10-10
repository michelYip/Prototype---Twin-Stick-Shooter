using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
	#region Exposed

	public static bool _inGame;

	public void PlayGame()
	{
		_inGame = true;
		Time.timeScale = 1;
		Instantiate(_levelManager);
	}

	public void QuitApplication()
	{
		Debug.Log("Quitting App");
		Application.Quit();
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		_pauseMenu.SetActive(false);
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		_startMenu.SetActive(true);
		_pauseMenu.SetActive(false);

		GameObject existingLevel = GameObject.FindGameObjectWithTag("Level");
		Destroy(existingLevel);

		_inGame = false;
	}

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_pauseMenu = transform.Find("PauseMenu").gameObject;
		_startMenu = transform.Find("StartMenu").gameObject;
		_inGame = false;
	}

	private void Update()
	{
		if (Input.GetAxisRaw("Pause") >= 1 && _inGame)
		{
			Debug.Log("Pause");
			_pauseMenu.SetActive(true);
			Time.timeScale = 0;
		}
	}

	#endregion


	#region Private

	[SerializeField] private GameObject _levelManager;
	private GameObject _pauseMenu;
	private GameObject _startMenu;

	#endregion
}