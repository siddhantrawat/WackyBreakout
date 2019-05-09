using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

	// Use this for initializatio
	void Start () {
		Time.timeScale = 0;
	}
	
	public	void HandleOnClickResume()
	{
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
		Destroy (gameObject);
	}

	public void HandleOnClickQuit()
	{
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
		Destroy (gameObject);
		SceneManager.LoadScene ("MainMenu");
	}
}
