using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    #region Exposed

    [SerializeField] private float m_rotationSpeed = 15f;
    [SerializeField] private float m_walkSpeed = 3f;

    #endregion


    #region UnityAPI

    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyTransform  = GetComponent<Transform>();
        _enemyRigidbody  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TurnTowardsPlayer();
        _enemyRigidbody.MovePosition(_enemyRigidbody.position + (transform.forward * m_walkSpeed * Time.fixedDeltaTime));
    }

    #endregion


    #region Private

    private Transform _playerTransform;
    private Transform _enemyTransform;
    private Rigidbody _enemyRigidbody;

    private void TurnTowardsPlayer()
	{
        Vector3 direction = (_playerTransform.position - _enemyTransform.position).normalized;
        float singleStep = m_rotationSpeed * Time.fixedDeltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        _enemyRigidbody.MoveRotation(Quaternion.LookRotation(newDirection));

        _enemyRigidbody.velocity = Vector3.zero;
        _enemyRigidbody.angularVelocity = Vector3.zero;
    }

    #endregion
}
