using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        Destroy(collision.gameObject);
        Destroy(this.gameObject);

        Debug.Log("b");
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
