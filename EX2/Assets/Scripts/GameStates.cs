using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public TMP_Text mControlMode;
    public TMP_Text mTouchedEnemy;
    public TMP_Text mEnemyCount;
    public TMP_Text mScore;
    public TMP_Text mBulletCount;

    public SpawnManager mSpawnManager;
    public PlayerBehavior mPlayerBehavior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        mControlMode.text = "Control Mode : " + mPlayerBehavior.mPlayerMoveMode.ToString();
        mControlMode.color = Color.red;
        mTouchedEnemy.text = "Touched Enemy : " + mSpawnManager.mPlayerTouched.ToString();
        mEnemyCount.text = "Enemy Count : " + mSpawnManager.mEnemyCount.ToString();
        mScore.text = "Score : " + mSpawnManager.mDestroyedEnemyCount.ToString();
        mBulletCount.text = "Bullet Count : " + mPlayerBehavior.BulletCount.ToString();
    }
}
