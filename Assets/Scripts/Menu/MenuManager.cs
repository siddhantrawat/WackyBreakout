using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class MenuManager {

	public static void GoToMenu(MenuName name)
	{
		switch (name) {
		case MenuName.Play:
                {
                    SceneManager.LoadScene("Gameplay");
                    break;
                }
		case MenuName.Quit:
                {
                    Application.Quit();
                    break;
                }
		case MenuName.Pause:
                {
                    Object.Instantiate(Resources.Load("PauseMenu"));
                    break;
                }
		case MenuName.Help:
			{
				SceneManager.LoadScene ("Help");
				break;
			}
            case MenuName.GameOver:
                {
                    Object.Instantiate(Resources.Load("GameOverMenu"));
                    break;
                }
		}
	}
}
