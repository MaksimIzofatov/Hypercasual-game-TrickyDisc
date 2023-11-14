using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionsHandler : MonoBehaviour
{

	
	[SerializeField] private UnityEvent _enemyDestroyed;
	[SerializeField] private UnityEvent _playerGameStartPoint;
	[SerializeField] private UnityEvent _playerDied;




	private void OnTriggerEnter2D(Collider2D collaider)
	{
		if (collaider.CompareTag(GlobalConstans.BORDER_TAG))
		{
			_playerDied.Invoke();
		}

		if(collaider.TryGetComponent(out EnemyController enemyController))
		{
			enemyController.Destroy();
			_enemyDestroyed.Invoke();
		}

		if(collaider.CompareTag(GlobalConstans.PLAYER_START_POINT_TAG))
		{
			_playerGameStartPoint.Invoke();
		}
	}
}
