using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BomScript : MonoBehaviour


{
   

    public GameObject Ban;
  



    private void OnDestroy()
    {
        Debug.Log("aaa");

        //BoardScript boardscript; //�ĂԃX�N���v�g�ɂ����Ȃ���
        //GameObject obj = GameObject.Find("Board"); //Player���Ă����I�u�W�F�N�g��T��
        //boardscript = obj.GetComponent<BoardScript>();�@//�t���Ă���X�N���v�g���擾
        //boardscript.Score +=10 ;

        BoardScript.instance.tostoring();


        Instantiate(Ban, this.transform.position, Quaternion.identity);

       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
