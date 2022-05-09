using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    //やること

    //変数の作成//
    //ボード基盤用の四角枠格納用
    //ボードの高さ
    //ボードの幅
    //ボードの高さ調整用数値

    [SerializeField] 
    private Transform emptySprite;

    [SerializeField]
    private int hight = 30, width = 10, header = 8;


    //関数の作成//
    //ボードを生成する関数の作成

    void CreateBoard()
    {
        if (emptySprite)
        {
            for (int y = 0; y < hight - header; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Transform clone = Instantiate(emptySprite, new Vector3(x, y, 0), Quaternion.identity);

                    clone.transform.parent = transform;
                }
            }

        }
    }

    void Start()
    {
        CreateBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
