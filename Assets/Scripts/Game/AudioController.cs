using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	private int _soundVolume;

	[SerializeField] private Image _image;
    [SerializeField] private Sprite _activeSoundSprite;
    [SerializeField] private Sprite _inactiveSoundSprite;

   

	private void Awake()
	{
		_soundVolume = PlayerPrefs.GetInt(GlobalConstans.SOUND_ENABLED_PREFS_KEY, 1);
		SetSoundValue();

	}

	private void SetSoundValue()
	{
		AudioListener.volume = _soundVolume;
		_image.sprite = _soundVolume == 1 ? _activeSoundSprite : _inactiveSoundSprite;
	}

	public void ToggleSound()
	{
		_soundVolume = _soundVolume == 1 ? 0 : 1;
		SetSoundValue();
		SaveSoundVolume();
	}

	private void SaveSoundVolume()
	{
		PlayerPrefs.SetInt(GlobalConstans.SOUND_ENABLED_PREFS_KEY, _soundVolume);
		PlayerPrefs.Save();
	}
}
