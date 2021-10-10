using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
	#region Exposed

	#endregion


	#region UnityAPI

	private void Update()
    {
        _inputXLook = Input.GetAxisRaw("HorizontalLook");
        _inputZLook = Input.GetAxisRaw("VerticalLook");
    }

	private void FixedUpdate()
    {
        _orientationInput = new Vector3(_inputXLook, 0, _inputZLook);
        //Debug.Log(_orientationInput);
        if (_orientationInput != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(_orientationInput);
    }

    #endregion


    #region Private

    private float _inputXLook;
    private float _inputZLook;
    private Vector3 _orientationInput;

    #endregion
}