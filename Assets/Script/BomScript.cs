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

        //BoardScript boardscript; //呼ぶスクリプトにあだなつける
        //GameObject obj = GameObject.Find("Board"); //Playerっていうオブジェクトを探す
        //boardscript = obj.GetComponent<BoardScript>();　//付いているスクリプトを取得
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
