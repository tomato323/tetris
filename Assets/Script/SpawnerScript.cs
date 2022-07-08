using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update

    //�z��̍쐬�i��������u���b�N���ׂĂ��i�[����j

    [SerializeField]
    BlockScript[] Blocks;

    int bomSpawner = 0;
    int i;
    

    //�֐��̍쐬//
    //�����_���ȃu���b�N��1�I�Ԋ֐�
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


    //�I�΂ꂽ�u���b�N�𐶐�����֐�

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
