using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Vector3 _startPosition;
	private bool _isMoving;

	[SerializeField] private Rigidbody2D _rigidbody;
	[SerializeField] private float _movementVelocity;
	[SerializeField] private SpriteRenderer _aimSprite;
	[SerializeField] private PlayerRotator _playerRotator;
	[SerializeField] private UserMoveTimeLimiter _userMoveTimeLimiter;
	[SerializeField] private AudioSource _moveAudioClip;
	[SerializeField] private ParticleSystem _deathParticlesPrefab;

	private void Awake()
	{
		_startPosition = transform.position;
		_isMoving = false;
	}
	public void Move()
	{
        if (!_isMoving)
        {
			_isMoving = !_isMoving;
			_aimSprite.enabled = false;
			_playerRotator.StopRotation();
			_userMoveTimeLimiter.StopTimeLimiter();
			_moveAudioClip.Play();

			_rigidbody.velocity = _movementVelocity * transform.up;
		}
	}

	public void OnPlayerDied()
	{
		Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public void ChangeDirection()
	{
		_rigidbody.velocity *= -1;
	}

	public void ResetPosition()
	{
		if (_isMoving)
		{
			_isMoving = !_isMoving;
			_aimSprite.enabled = true;
			_playerRotator.StartRotation();
			_userMoveTimeLimiter.RestartTimeLimiter();

			_rigidbody.velocity = Vector2.zero;
			transform.position = _startPosition;
		}
	}
}
