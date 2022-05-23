using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    //変数の作成//
    //スポナー
    //生成されたブロック格納

    SpawnerScript spawner;
    BlockScript activeBlock;


    //スポナーオブジェクトをスポナー変数に格納するコードの記述

    [SerializeField]
    private float dropInterval = 0.25f;
    float nextdropTimer;


    private void Start()
    {
        spawner = GameObject.FindObjectOfType<SpawnerScript>();


        if (!activeBlock)
        {

            activeBlock = spawner.SpawnBlock();
        }

       
    }

    private void Update()
    {
        if (Time.time > nextdropTimer)
        {
            nextdropTimer = Time.time + dropInterval;

            if (activeBlock)
            {

                activeBlock.MoveDown();
            }
        }


        
    }

    //スポナークラスからブロック生成関数を呼んで変数に格納する


    // Update is called once per frame

}
