using System.Collections.Generic;
using UnityEngine;

public class AudioOnDestroy : MonoBehaviour
{
	#region Exposed

	public float m_volume = 1f;
	public List<AudioClip> m_audioArray;

	#endregion


	#region UnityAPI

	private void Awake()
	{
		_AudioSource = GetComponent<AudioSource>();
	}

	private void OnDisable()
	{
		foreach (AudioClip audio in m_audioArray)
		{
			AudioSource.PlayClipAtPoint(audio, transform.position, m_volume);
		}
	}

	#endregion


	#region Private

	private AudioSource _AudioSource;

	#endregion
}