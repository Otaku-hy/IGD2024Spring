using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int mEnemyCount = 0;
    public int mDestroyedEnemyCount = 0;
    public int mPlayerTouched = 0;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBehavior.SetSpawnManager(this);

        while(mEnemyCount < 10)
        {
            RandomGenerateEnemy();
            IncreaseEnemyCount();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mEnemyCount < 10)
        {
            RandomGenerateEnemy();
            IncreaseEnemyCount();
        }
    }

    void RandomGenerateEnemy()
    {
        CameraBoundingUpdate cameraBoundingUpdate = Camera.main.GetComponent<CameraBoundingUpdate>();

        Vector3 BoundingBottomLeft = cameraBoundingUpdate.GetBoundingBottomLeft() * 0.9f; //magic number: scene scale
        Vector3 BoundingTopRight = cameraBoundingUpdate.GetBoundingTopRight() * 0.9f;

        float x = Random.Range(BoundingBottomLeft.x,BoundingTopRight.x);
        float y = Random.Range(BoundingBottomLeft.y,BoundingTopRight.y);

        GameObject enemy = Instantiate(Resources.Load("Prefabs/Enemy"), new Vector3(x, y, 0), Quaternion.identity) as GameObject;
    }

    public void DecreaseEnemyCount()
    {
        mEnemyCount--;
    }

    public void IncreaseEnemyCount()
    {
        mEnemyCount++;
    }

    public void IncreaseDestroyedEnemyCount()
    {
        mDestroyedEnemyCount++;
    }

    public void IncreasePlayerTouched()
    {
        mPlayerTouched++;
    }
}
