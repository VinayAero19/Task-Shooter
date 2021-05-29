using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timer = 0f;
    public float shrinkTime = 2f;
    public float minSize = 0f;
    public bool isMinSize = false;


    public float scanRadius;
    public LayerMask filterMask;
    private Collider2D checkCollider;


    void Start()
    {
       

       
    }

    // Update is called once per frame
    void Update()
    {
        // To check whether enemies are randomly spawning and overlapping eachother
        checkCollider = Physics2D.OverlapCircle(transform.position, scanRadius, filterMask);

        if (checkCollider != null && checkCollider.transform != transform)
        {
            Destroy(checkCollider.gameObject);

        }
    }

    public void Resize()
    {
        StartCoroutine(ShrinkEnemy());

    }

    //Resizing enemy
    public  IEnumerator ShrinkEnemy()
    {
        Vector3 StartScale = transform.localScale;
        Vector3 minScale = new Vector3(minSize, minSize,minSize);
        do
        {
            transform.localScale = Vector3.Lerp(StartScale, minScale, timer / shrinkTime);
            timer += Time.deltaTime;         
            yield return null;
           
        }
        while (timer < shrinkTime);
        isMinSize = true;
        Destroy(gameObject);
        
       
    }

    //Radius indicator 
    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }

    





}
