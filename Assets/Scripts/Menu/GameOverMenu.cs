using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text scoreText;
    string prefixScore;

    void Start()
    {

        int score = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>().GetScore();
        prefixScore = scoreText.text;
        scoreText.text = prefixScore + score;
    }
    public void HandleOnClickQuit()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
}
