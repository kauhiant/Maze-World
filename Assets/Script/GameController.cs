using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Script;

public class GameController : MonoBehaviour {

    static public int level = 1;
    static public float rateOfEnemy = 0.2f;

    private int sizeOfMaze;
    private char sudo = '0';
    private bool isEnd = false;

    public OneHot BGMManager;

    public GameObject road;
    public GameObject wall;
    public GameObject food;
    public GameObject enemy;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject adminPanel;
    public Text levelInfo;
    public Text goldInfo;
    public Text coinsInfo;
    public PlayerController player;
    public TimeController timeController;
    public int targetGold = 0;
    public int sizeOfEnemys = 0;

    // if scene index not found : quit game.
    public void GotoSecen(int sceneInedx)
    {
        try
        {
            SceneManager.LoadScene(sceneInedx);
        }
        catch
        {
            Application.Quit();
        }
    }

    public void NextLevel()
    {
        ++level;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayerUnDead()
    {
        player.UnDead();
        isEnd = false;
        BGMManager.SetActive(true);
    }


	// Use this for initialization
	void Start () {
        this.sizeOfMaze = 24 + 8 * level;
        int center = sizeOfMaze / 2;

        var creater = new MazeCreater(sizeOfMaze);
        creater.CreateMap();
        var map = creater.ChangeSomeLeavesForstep(rateOfEnemy * 2.5f, sizeOfMaze / 2, 'e');

        for(int x = 0; x<map.GetLength(0); ++x)
        {
            for(int y = 0; y < map.GetLength(1); ++y)
            {
                GameObject gameObject = null;
                if (map[x, y] == 'r')
                {
                    gameObject = GameObject.Instantiate(road);
                }
                else if(map[x, y] == 'h')
                {

                    GameObject.Instantiate(road, new Vector2(x, y), new Quaternion());
                    gameObject = GameObject.Instantiate(food);
                    ++targetGold;

                }
                else if (map[x, y] == 'e')
                {
                    GameObject.Instantiate(road, new Vector2(x, y), new Quaternion());
                    gameObject = GameObject.Instantiate(enemy);
                    ++sizeOfEnemys;
                }
                else
                {
                    gameObject = GameObject.Instantiate(wall);
                }

                gameObject.transform.position = new Vector2(x, y);
            }
        }

        player.transform.position = new Vector2(center, center);

        if (rateOfEnemy == 0)
            BGMManager.SetOneHot(0);
        else
            BGMManager.SetOneHot(1);
	}
	
	// Update is called once per frame
	void Update () {
        InfoUpdate();

        if (Input.GetKeyDown(KeyCode.S) && sudo == '0')
        {
            sudo = 's';
        }else if(Input.GetKeyDown(KeyCode.U) && sudo == 's')
        {
            sudo = 'u';
        }else if(Input.GetKeyDown(KeyCode.D) && sudo == 'u')
        {
            sudo = 'd';
        }else if(Input.GetKeyDown(KeyCode.O) && sudo == 'd')
        {
            sudo = '0';
            adminPanel.SetActive(true);
        }
        else if (Input.anyKeyDown)
        {
            sudo = '0';
        }

	}

    private void InfoUpdate()
    {
        if (isEnd)
            return;

        levelInfo.text = string.Format("Level {0} [{1} x {1}]", level, sizeOfMaze);
        goldInfo.text = string.Format("Stars : {0} / {1}", player.GetGolds, targetGold);
        coinsInfo.text = string.Format("Coins : {0}", player.Coins);

        if (player.IsDead)
        {
            losePanel.SetActive(true);
            timeController.SetStop(true);
            BGMManager.SetActive(false);
            isEnd = true;
        }

        if (player.GetGolds == targetGold)
        {
            winPanel.SetActive(true);
            timeController.SetStop(true);
            BGMManager.SetActive(false);
            isEnd = true;
        }
    }
}
