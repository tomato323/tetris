using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    //��邱��

    //�ϐ��̍쐬//
    //�{�[�h��՗p�̎l�p�g�i�[�p
    //�{�[�h�̍���
    //�{�[�h�̕�
    //�{�[�h�̍��������p���l

    [SerializeField] 
    private Transform emptySprite;

    [SerializeField]
    private int hight = 30, width = 10, header = 8;


    //�֐��̍쐬//
    //�{�[�h�𐶐�����֐��̍쐬

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
