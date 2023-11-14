using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] private float _sceneChangeDelay;

	private void Awake()
	{
		//максимальное значение кадров в секунду
		Application.targetFrameRate = 60;
	}
	public void OnPlayerDied()
	{
		StartCoroutine(ShowGameOver());
	}

	private IEnumerator ShowGameOver()
	{
		yield return new WaitForSeconds(_sceneChangeDelay);
		SceneManager.LoadSceneAsync(GlobalConstans.GAME_OVER_SCENE);
	}
}
