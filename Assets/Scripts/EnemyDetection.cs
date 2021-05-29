using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetection : MonoBehaviour
{
    float distanceToNearestEnemy;
    Enemy nearestEnemy;
    private Enemy[] TotalEnemies;
    public GameObject bullet;
    public Transform ShootPos;
    private Vector2 direction;
    public float force;
    public GameObject  im;
    private AudioSource audio;
    public AudioClip fireSound;
    public AudioClip winSound;

    private GameManager gm;
    void Start()
    {
        im.SetActive(false);
        audio = GetComponent<AudioSource>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }


    void Update()
    {
       
    }

    //Detect Enmie nearest to player
     public void DetectNearestEnemy()
    {
        distanceToNearestEnemy = Mathf.Infinity;
        nearestEnemy = null;
        TotalEnemies = GameObject.FindObjectsOfType<Enemy>();


        foreach (Enemy currentEnemy in TotalEnemies)
        {
           
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToNearestEnemy)
            {
                distanceToNearestEnemy = distanceToEnemy;
                nearestEnemy = currentEnemy;

            }
            if (TotalEnemies.Length <= 1)
            {
                Invoke("ShowMessage", 2.5f);
               
            }

        }
                   
            Debug.DrawLine(this.transform.position, nearestEnemy.transform.position, Color.red);
            direction = nearestEnemy.transform.position - transform.position;
            transform.up = direction;
            if(TotalEnemies.Length >=1)
            {
               Fire();
            }
            

    }

    // firing mechanism
    void Fire()
    {

        GameObject newBullet = Instantiate(bullet, ShootPos.transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(direction * force);
        audio.clip = fireSound;
        audio.Play();

    } 

    // Win Message
    void ShowMessage()
    {

        im.SetActive(true);
        gm.replayButton.SetActive(true);
        audio.clip = winSound;
        audio.Play();

    }

  
  
    
}
