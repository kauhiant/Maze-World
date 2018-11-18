using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

    public int targetSceneIndex = 1;
    
    public void LoadGame(float rateOfMonster)
    {
        GameController.rateOfEnemy = rateOfMonster;
        SceneManager.LoadScene(targetSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

}
