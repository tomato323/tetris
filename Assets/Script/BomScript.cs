using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomScript : MonoBehaviour


{

    public GameObject Shikaku;
    private void OnDestroy()
    {
        Debug.Log("aaa");

        Shikaku.GetComponent<BoxCollider2D>().isTrigger = false;
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
