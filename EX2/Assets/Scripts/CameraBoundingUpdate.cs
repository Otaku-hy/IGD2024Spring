using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundingUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 BoundingBottomLeft;
    private Vector3 BoundingTopRight;
    void Start()
    {
        
    }

    private void Awake()
    {
        BoundingUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        BoundingUpdate();
    }

    void BoundingUpdate()
    {
        BoundingBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        BoundingTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    public Vector3 GetBoundingBottomLeft()
    {
        return BoundingBottomLeft;
    }

    public Vector3 GetBoundingTopRight()
    {
        return BoundingTopRight;
    }

    public bool IsOutsideWorldBounding(Bounds ObjectBound)
    {
        if(ObjectBound.max.x > BoundingTopRight.x
            || ObjectBound.max.y > BoundingTopRight.y
            || ObjectBound.min.x < BoundingBottomLeft.x
            || ObjectBound.min.y < BoundingBottomLeft.y)
            return true;
        return false;
    }
}
