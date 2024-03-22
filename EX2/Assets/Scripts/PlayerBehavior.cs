using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float RotateSpeed = 45.0f;
    private float MoveSpeed = 20.0f;
    private float acceleration = 3.0f;

    private static float SpawnCoolTime = 0.2f;

    private float CurrentCoolTime = 0.0f;

    public int BulletCount = 0;

    public enum PlayerMoveMode
    {
        MouseMode = 0, //default move mode
        KeyboardMode = 1
    }

    public PlayerMoveMode mPlayerMoveMode = PlayerMoveMode.MouseMode; 
        
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        SpawnEgg();

        if(Input.GetKeyDown(KeyCode.M))
        {
            mPlayerMoveMode =  (PlayerMoveMode)(((int)mPlayerMoveMode + 1)%2);
        }

        switch (mPlayerMoveMode)
        {
            case PlayerMoveMode.MouseMode:
                MoveWithMouse();
                break;
            case PlayerMoveMode.KeyboardMode:
                MoveWithKeyBoard();
                break;
        }

    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.forward, -RotateSpeed * Time.deltaTime);
    }
    
    void MoveWithMouse()
    {       
        Vector3 MovePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MovePosition.z = 0;
        transform.position = MovePosition;
    }

    void MoveWithKeyBoard()
    {
        MoveSpeed += Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        transform.Translate(transform.up * MoveSpeed * Time.deltaTime, Space.World);
    }

    void SpawnEgg()
    {
        if (CurrentCoolTime > 0.0f)
        {
            CurrentCoolTime -= Time.deltaTime;
            return;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            CurrentCoolTime = SpawnCoolTime;
            Object bullet = Instantiate(Resources.Load("Prefabs/Egg"), transform.position, transform.rotation);
            BulletBehavior bulletBehavior = bullet.GetComponent<BulletBehavior>();
            bulletBehavior.SetPlayer(this);
            IncreaseBulletCount();
        }
    }

    public void IncreaseBulletCount()
    {
        BulletCount++;
    }

    public void DecreaseBulletCount()
    {
        BulletCount--;
    }
}
