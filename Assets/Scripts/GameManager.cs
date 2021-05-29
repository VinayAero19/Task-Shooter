using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int numToSpawn;
    public GameObject Enemy;
    private Enemy enemy;
    private bool isSpawn = false;

    public GameObject replayButton;
    public bool IsGameOver = false;
    

    void Start()
    {
        if(!IsGameOver)
        {
            enemy = GameObject.FindObjectOfType<Enemy>();
            SpawnEnemies();

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void SpawnEnemies()
    {
      

            for (int i = 0; i < numToSpawn; i++)
            {
                float screenX = Random.Range(-5.5f, 5.5f);
                float screenY = Random.Range(1f, 4f);

                Vector2 pos = new Vector2(screenX, screenY);
                pos = new Vector2(screenX, screenY);

                Instantiate(Enemy, pos, Quaternion.identity);
            }      
    }

    public void Reset()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
