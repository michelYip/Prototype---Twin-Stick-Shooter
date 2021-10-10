using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [Header("Movement Value")]
    [SerializeField] private float m_playerMaxSpeed = 10f;

    private float m_radius = 1f;

	#endregion


	#region UnityAPI

	private void Start()
	{
        _rigidBody = GetComponent<Rigidbody>();
    }

	private void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");
        _inputZ = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(_inputX, 0, _inputZ).normalized;
        int collisionCount = 0;
        Vector3 normalCollision = GetNormalCollision(out collisionCount);

        if (collisionCount > 0)
        {
            double threshold = GetThreshold(collisionCount); // Need to compute dynamically
            double dotProduct = Vector3.Dot(inputDir, normalCollision);
            //Debug.Log("("+threshold+") "+inputDir + " Dot " + normalCollision + " = " + dotProduct);
            if (dotProduct < threshold)
            {
                //Debug.Log(inputDir.x * normalCollision.x + " -> " + Mathf.RoundToInt(inputDir.x * normalCollision.x));
                //Debug.Log(inputDir.z * normalCollision.z + " -> " + Mathf.RoundToInt(inputDir.z * normalCollision.z));
                inputDir.x = (Mathf.Sign(Mathf.RoundToInt((inputDir.x * normalCollision.x) * 10)) == -1) ? 0 : inputDir.x;
                inputDir.z = (Mathf.Sign(Mathf.RoundToInt((inputDir.z * normalCollision.z) * 10)) == -1) ? 0 : inputDir.z;
                //Debug.Log(inputDir.x + " | " + inputDir.z);
            }
        }
        _velocity = new Vector3(inputDir.x * m_playerMaxSpeed * Time.fixedDeltaTime,
                                0,
                                inputDir.z * m_playerMaxSpeed * Time.fixedDeltaTime);
        _rigidBody.MovePosition(_velocity + _rigidBody.position);
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.angularVelocity = Vector3.zero;
    }

    #endregion


    #region Private

    private float _inputX;
    private float _inputZ;
    private Vector3 _velocity;
    private Rigidbody _rigidBody;

    public Vector3 GetNormalCollision(out int n)
	{
        Vector3 normalSum = Vector3.zero;
        int layerMask = 1 << 11; //Wall Layer Mask
        List<Vector3> collisionsNormal = new List<Vector3>();
        Collider[] colliders = Physics.OverlapSphere(_rigidBody.position, m_radius, layerMask);
        if (colliders.Length != 0)
        {
            foreach (Collider c in colliders)
                collisionsNormal.Add((transform.position - c.ClosestPoint(transform.position)).normalized);
        }
        if (collisionsNormal.Count > 0)
        {
            foreach (Vector3 c in collisionsNormal)
                normalSum += c;
            normalSum.Normalize();
        }
        n = collisionsNormal.Count;
        return normalSum;
    }

    public float GetThreshold(int count)
	{
        if (count == 1) return 0;
        else if (count == 2) return 0.8f;
        else return 1f;
	}

    #endregion
}