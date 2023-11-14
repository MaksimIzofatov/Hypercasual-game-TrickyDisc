using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadSceneAsync(GlobalConstans.GAME_SCENE);
	}
}
