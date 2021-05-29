using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Enemy>().Resize();
        
        Destroy(this.gameObject);
    }


    
}
