using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private float _minPointX;
	private float _maxPointX;
	private SpriteRenderer _enemySprite;
	private float _delayBetweenMovements;
	private Sequence _moveSequence;

	[SerializeField] private float _minMovingDuration;
	[SerializeField] private float _maxMovingDuration;
	[SerializeField] private ParticleSystem _deathParticlesPrefab;




	public void Initialize(float minPointX, float maxPointX, float delayBetweenMovements)
	{
		_enemySprite = GetComponent<SpriteRenderer>();
		var offsetX = _enemySprite.bounds.size.x / 2;

		_minPointX = minPointX;
		_maxPointX = maxPointX;
		_delayBetweenMovements = delayBetweenMovements;

		Move();
	}

	public void Destroy()
	{
		Instantiate(_deathParticlesPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private float GetRandomMovementDuration()
	{
		return Random.Range(_minMovingDuration, _maxMovingDuration);
	}

	private float GetNextRandomPositionX()
	{
		return Random.Range(_minPointX, _maxPointX);
	}

	private void Move()
	{
		var randomDur = GetRandomMovementDuration();
		var nextPosition = GetNextRandomPositionX();

		_moveSequence = DOTween.Sequence();


		_moveSequence.Append(transform.DOMoveX(nextPosition, randomDur));
		_moveSequence.AppendInterval(_delayBetweenMovements);
		_moveSequence.OnComplete(Move);
	}

	private void OnDestroy()
	{
		_moveSequence.Kill();
	}
}
