using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLastBallListener(GameOverMenu);
        
        
    }

    public void GameOverMenu()
    {
        Time.timeScale = 0;
        if(GameObject.FindGameObjectsWithTag("GameOverPrefab").Length==0)
        MenuManager.GoToMenu(MenuName.GameOver);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("StandardBlock").Length +
   GameObject.FindGameObjectsWithTag("BonusBlock").Length +
   GameObject.FindGameObjectsWithTag("PickUpBlock").Length == 1)
            EventManager.AddBlockDestroyListerner(GameOverMenu);

    }
}
