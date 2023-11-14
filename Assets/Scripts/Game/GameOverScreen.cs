using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _currentScoreLabel;
	[SerializeField] private TextMeshProUGUI _bestScoreLabel;
	[SerializeField] private float _newBestScoreAnimationDuration;
	[SerializeField] private AudioSource _bestScoreChangedSound;

	private void Awake()
	{
		var currentScore = PlayerPrefs.GetInt(GlobalConstans.SCORE_PREFS_KEY);
		var bestScore = PlayerPrefs.GetInt(GlobalConstans.BEST_SCORE_PREFS_KEY);

		if(currentScore > bestScore)
		{
			bestScore = currentScore;
			SaveNewBestSore(bestScore);
			ShowNewBestScoreAnimation();
		}

		_currentScoreLabel.text = currentScore.ToString();
		_bestScoreLabel.text = $"BEST {bestScore}";
	}

	private void ShowNewBestScoreAnimation()
	{
		_bestScoreLabel.transform.DOPunchScale(Vector3.one, _newBestScoreAnimationDuration, 0);
		_bestScoreChangedSound.Play();
	}

	private void SaveNewBestSore(int bestScore)
	{
		PlayerPrefs.SetInt(GlobalConstans.BEST_SCORE_PREFS_KEY, bestScore);
		PlayerPrefs.Save();
	}

	public void RestartGame()
	{
		SceneManager.LoadSceneAsync(GlobalConstans.GAME_SCENE);
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}
}
