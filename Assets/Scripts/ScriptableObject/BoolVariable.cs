using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{

	#region Exposed

	public bool _value;

	public void SetBool(bool value)
	{
		_value = value;
	}

	#endregion

	#region UnityAPI
	#endregion

	#region Private
	#endregion
}
