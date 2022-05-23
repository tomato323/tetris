using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    //�ϐ��̍쐬//
    //�X�|�i�[
    //�������ꂽ�u���b�N�i�[

    SpawnerScript spawner;
    BlockScript activeBlock;


    //�X�|�i�[�I�u�W�F�N�g���X�|�i�[�ϐ��Ɋi�[����R�[�h�̋L�q

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

    //�X�|�i�[�N���X����u���b�N�����֐����Ă�ŕϐ��Ɋi�[����


    // Update is called once per frame

}
