using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    //変数の作成//
    //スポナー
    //生成されたブロック格納

    SpawnerScript spawner;
    BlockScript activeBlock;

    BoardScript board;

    float nextKeyDownTimer, nextKeyLeftRightTimer,nextKeyRotateTimer;

    public Text lastScoreText;
    int lastScore;

    public Text scoreText;
    private int score;

  
    [SerializeField]
    private float nextKeyDownInterval, nextKeyLeftRightInterval,nextKeyRotateInterval;

    //スポナーオブジェクトをスポナー変数に格納するコードの記述

    [SerializeField]
    private GameObject gameOverPanel;

    bool gameOver;

    bool push = false;

    public AudioSource BGM;

    [SerializeField]
    private float dropInterval = 0.25f;
    float nextdropTimer;


    private void Start()
    {
        spawner = GameObject.FindObjectOfType<SpawnerScript>();

        board = GameObject.FindObjectOfType<BoardScript>();

        spawner.transform.position = RoundingScript.Round(spawner.transform.position);

        nextKeyDownTimer = Time.time + nextKeyDownInterval;
        nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;
        nextKeyRotateTimer = Time.time + nextKeyRotateInterval;





        if (!activeBlock)
        {

            activeBlock = spawner.SpawnBlock();
        }

        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
        }
       
    }

    private void Update()
    {

        if (gameOver)
        {
            return;
        }

        PlayerInput();

       
    }


    void PlayerInput()
    {
        if (Input.GetKey(KeyCode.D) && (Time.time > nextKeyLeftRightTimer)||Input.GetKeyDown(KeyCode.D))
        {
            activeBlock.MoveRight();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveLeft();
            }
        }

        else if (Input.GetKey(KeyCode.A) && (Time.time > nextKeyLeftRightTimer) || Input.GetKeyDown(KeyCode.A))
        
        {
            activeBlock.MoveLeft();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveRight();
            }
        }

        else if (Input.GetKey(KeyCode.E) && (Time.time >nextKeyRotateTimer))
        {
            activeBlock.RotateRight();
            nextKeyRotateTimer = Time.time + nextKeyRotateInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.RotateLeft();
            }

        }
        else if (Input.GetKey(KeyCode.S) && (Time.time > nextKeyDownTimer) || (Time.time > nextdropTimer))

        {
            activeBlock.MoveDown();

           
            nextKeyLeftRightTimer = Time.time + nextKeyDownInterval;
            nextdropTimer =  Time.time + dropInterval;

            if (!board.CheckPosition(activeBlock))
            {
                if (board.OverLimit(activeBlock))
                {
                    GameOver();
                }
                else
                {

                    BottomBoard();
                }
            }
        }
        if (push)
        {
            DownButton();
        }
    }

    void BottomBoard()
    {
        activeBlock.MoveUp();
        board.SaveBlockInGrid(activeBlock);

        activeBlock = spawner.SpawnBlock();

        nextKeyDownTimer = Time.time;
        nextKeyLeftRightTimer = Time.time;
        nextKeyRotateTimer = Time.time;

        board.ClearAllRows();

    }

    //スポナークラスからブロック生成関数を呼んで変数に格納する


    // Update is called once per frame

    void GameOver()
    {
        activeBlock.MoveUp();

        if (!gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(true);

            Destroy(BGM);
        }

        gameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("StartScene");
    }

   
    public void RightButton ()
    {
       
            activeBlock.MoveRight();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveLeft();
            }
    }
    public void LeftButton()
    {
       
            activeBlock.MoveLeft();

            nextKeyLeftRightTimer = Time.time + nextKeyLeftRightInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.MoveRight();
            }
        
    }
    public void DownButton()
    {
       
            activeBlock.MoveDown();


            nextKeyLeftRightTimer = Time.time + nextKeyDownInterval;
            nextdropTimer = Time.time + dropInterval;

            if (!board.CheckPosition(activeBlock))
            {
                if (board.OverLimit(activeBlock))
                {
                    GameOver();
                }
                else
                {

                    BottomBoard();
                }
            }
        
        
    }
    public void RightRotationButton()
    {
        if(Time.time > nextKeyRotateTimer)
        {
            activeBlock.RotateRight();
            nextKeyRotateTimer = Time.time + nextKeyRotateInterval;

            if (!board.CheckPosition(activeBlock))
            {
                activeBlock.RotateLeft();
            }

        }
    }
   
    public void PushDown()
    {
        push = true;
    }
    public void PushUp()
    {
        push = false;
    }


}
