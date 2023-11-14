using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
	private int _score;

	[SerializeField] private TextMeshProUGUI _scoreLabel;
	[SerializeField] private int _rewardPerEnemy;
	[SerializeField] private float _animationDuration;
	[SerializeField] private float _scaleFactor;
	[SerializeField] private AudioSource _scoreChangeAudioClip;

	private void Awake()
	{
		_scoreLabel.text = "0";
	}

	public void AddScore()
	{
		_score += _rewardPerEnemy;
		_scoreLabel.text = _score.ToString();
		_scoreChangeAudioClip.Play();
		_scoreLabel.transform.DOPunchScale(Vector3.one * _scaleFactor, _animationDuration, 0)
							.OnComplete(() => _scoreLabel.transform.localScale = Vector3.one);
		
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt(GlobalConstans.SCORE_PREFS_KEY, _score);
		PlayerPrefs.Save();
	}
}
