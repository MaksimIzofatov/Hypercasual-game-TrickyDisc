using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
	private InputControls _inputControls;

	[SerializeField] private PlayerController _playerController;

	private void Awake()
	{
		_inputControls = new InputControls();
		_inputControls.Player.Move.performed += OnMove;
	}

	private void OnMove(InputAction.CallbackContext context)
	{
		_playerController.Move();
	}

	private void OnEnable()
	{
		_inputControls.Enable();
	}

	private void OnDisable()
	{
		_inputControls.Disable();
	}

	private void OnDestroy()
	{
		_inputControls.Player.Move.performed -= OnMove;
	}
}
