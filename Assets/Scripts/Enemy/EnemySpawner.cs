using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	private float _minPointX;
	private float _maxPointX;

	[SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;
	[SerializeField] private float _delayBetweenMovements;

	private void Start()
	{
		Spawn();
	}

	private void Awake()
	{
		var camera = Camera.main;
		_minPointX = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
		_maxPointX = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
	}

	public void Spawn()
	{
		var spawnPoint = ShouldSpawnOnLeftSide() ? _leftSpawnPoint.position : _rightSpawnPoint.position;
		var currentEnemy = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity, transform);
		currentEnemy.Initialize(_minPointX, _maxPointX, _delayBetweenMovements);
	}

	private bool ShouldSpawnOnLeftSide()
	{
		var randomSpawn = Random.Range(0, 2);
		return randomSpawn == 1;
	}
}
