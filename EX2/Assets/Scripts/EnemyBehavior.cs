using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Color color;
    private uint HP = 4;

    private static SpawnManager spawnManager = null;

    public static void SetSpawnManager(SpawnManager manager)
    {
        spawnManager = manager;
    }
      
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spawnManager.IncreasePlayerTouched();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            color.a *= 0.8f;
            HP--;
            if(HP == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().material.color = color;
            }
        }
    }

    private void OnDestroy()
    {
        spawnManager.DecreaseEnemyCount();
        spawnManager.IncreaseDestroyedEnemyCount();
    }
}
