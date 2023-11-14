using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
	private float _currentTime;
	private Quaternion _quaternionMinAngleZ;
	private Quaternion _quaternionMaxAngleZ;
	private bool _canRotate;

	[SerializeField] private float _minAngleZ;
    [SerializeField] private float _maxAngleZ;
	[SerializeField] private float _duration;

	private void Awake()
	{
		_quaternionMinAngleZ = Quaternion.Euler(0f, 0f, _minAngleZ);
		_quaternionMaxAngleZ = Quaternion.Euler(0f, 0f, _maxAngleZ);
		_canRotate = true;
	}

	private void Update()
	{
		if (_canRotate)
			Rotate();
	}

	private void Rotate()
	{
		_currentTime += Time.deltaTime;
		var progress = Mathf.PingPong(_currentTime, _duration) / _duration;
		transform.rotation = Quaternion.Lerp(_quaternionMinAngleZ, _quaternionMaxAngleZ, progress);
	}

	public void StartRotation()
	{
		_canRotate = true;
	}

	public void StopRotation()
	{
		_canRotate = false;
	}
}
