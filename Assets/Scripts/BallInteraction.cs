using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallInteraction : MonoBehaviour
{
    [SerializeField] private float arcPower = 1.5f;
    [SerializeField] private float sideToSidePower = 2.0f;
    [SerializeField] private float throwPower = 2.0f;
    [SerializeField] private int baseScore = 5;
    [SerializeField] private int allNetMultiplier = 2;
    
    private GameManager _gameManager;
    private bool _hasBeenShot = false;
    private bool _hitGoal = false;
    private Rigidbody _myRigidbody;
    private Vector2 _startPosition;
    private float _timeMoving = 0.0f;

    public int GetScore()
    {
        return _hitGoal ? baseScore : baseScore * allNetMultiplier;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("goal"))
            _hitGoal = true;
    }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
            return;

        _gameManager.Input.BallThrow.StartThrow.performed += OnStartThrow;
        _gameManager.Input.BallThrow.StopThrow.performed += OnStopThrow;
        _myRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (_gameManager == null)
            return;
        
        _gameManager.Input.BallThrow.StartThrow.Enable();
        _gameManager.Input.BallThrow.StopThrow.Enable();
        _gameManager.Input.BallThrow.ThrowPosition.Enable();
    }

    private void OnDestroy()
    {
        if (_gameManager == null)
            return;
        
        _gameManager.Input.BallThrow.StartThrow.performed -= OnStartThrow;
        _gameManager.Input.BallThrow.StopThrow.performed -= OnStopThrow;
    }

    private void Update()
    {
        if (!_hasBeenShot)
            return;

        _timeMoving += Time.deltaTime;
        
        if(_timeMoving >= 15)
            Destroy(gameObject);
    }

    private void OnStartThrow(InputAction.CallbackContext context)
    {
        _startPosition = _gameManager.Input.BallThrow.ThrowPosition.ReadValue<Vector2>();
    }
    
    private void OnStopThrow(InputAction.CallbackContext context)
    {
        if (_startPosition == Vector2.zero)
            return;
        
        var endPosition = _gameManager.Input.BallThrow.ThrowPosition.ReadValue<Vector2>();
        Shoot(endPosition);
    }

    private void Shoot(Vector2 endPosition)
    {
        if (_hasBeenShot)
            return;

        var diff = (endPosition - _startPosition);
        var x = (diff.x * -1f) * sideToSidePower;
        var y = Mathf.Abs(diff.y) * arcPower;
        var z = Mathf.Abs(diff.y) * throwPower;

        var forceVector = new Vector3(x, y, z);
        Vector3 pos = transform.position;
        Debug.DrawRay(pos, forceVector, Color.red, 20);
        
        Debug.Log($"X: {x} Y: {y} Z: {z}");
        _myRigidbody.isKinematic = false;
        _myRigidbody.useGravity = true;
        _myRigidbody.AddRelativeForce(forceVector);
        _hasBeenShot = true;
        
        LevelManager.SpawnBall();
    }
}
