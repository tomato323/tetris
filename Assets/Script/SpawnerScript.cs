using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    //配列の作成（生成するブロックすべてを格納する）

    [SerializeField]
    BlockScript[] Blocks;

    int bomSpawner = 0;
    int i;
    

    //関数の作成//
    //ランダムなブロックを1つ選ぶ関数
    BlockScript GetRandomBlock()
    {

        bomSpawner++;
        i = Random.Range(0, Blocks.Length-1);

        if(bomSpawner == 10)
        {
            i = 7;
            bomSpawner = 0;

            //Instantiate(Shikaku,transform.position, Quaternion.identity);
           
        }

        if (Blocks[i])
        {
            return Blocks[i];
        }
        else
        {
            return null;
        }
    }

    internal BlockScript SpawnBlock()
    {
        BlockScript block = Instantiate(GetRandomBlock(), transform.position, Quaternion.identity);
       
        if (block)
        {
            return block;
        }
        else
        {
            return null;
        }
    }


    //選ばれたブロックを生成する関数

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
