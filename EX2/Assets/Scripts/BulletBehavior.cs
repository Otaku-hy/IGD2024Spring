using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private PlayerBehavior mPlayerBehavior;
    private float MoveSpeed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetPlayer(PlayerBehavior playerBehavior)
    {
        mPlayerBehavior = playerBehavior;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * MoveSpeed,Space.World);

        CameraBoundingUpdate cameraBoundingUpdate = Camera.main.GetComponent<CameraBoundingUpdate>();
        bool isOutside = cameraBoundingUpdate.IsOutsideWorldBounding(GetComponent<SpriteRenderer>().bounds);
        if (isOutside)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        mPlayerBehavior.DecreaseBulletCount();
    }

}
