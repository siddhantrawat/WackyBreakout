using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    private void Start()
    {
        Time.timeScale = 1;
    }

    public	void HandleOnClickQuitButtonEvent () {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu (MenuName.Quit);
       

    }

	public void HandleOnClickPlayButtonEvent()
	{
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu (MenuName.Play);
        
    }

	public void HandleOnClickHelpButtonEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu (MenuName.Help);
      

    }
}
