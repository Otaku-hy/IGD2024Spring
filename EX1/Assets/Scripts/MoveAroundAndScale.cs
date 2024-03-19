using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundAndScale : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /// control position
        Vector2 MoveAxis = new Vector2(transform.position.x, transform.position.y);
        MoveAxis.Normalize();
        Vector2 Flag = new Vector2(MoveAxis.x > 0 ? 1 : -1, MoveAxis.y > 0 ? 1 : -1);

        transform.Translate(MoveAxis * Input.GetAxis("Vertical") * MoveSpeed, Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Mathf.Min(Flag.x * 1, Flag.x * 50), Mathf.Max(Flag.x * 1, Flag.x * 50)), Mathf.Clamp(transform.position.y, Mathf.Min(Flag.y * 1, Flag.y * 50), Mathf.Max(Flag.y * 1, Flag.y * 50)), transform.position.z);

        /// control scale
        float s = Input.GetAxis("Vertical") * 0.1f;
        Vector3 ScaleSize = new Vector3(s, s, s);

        transform.localScale += ScaleSize;
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1.0f, 6.0f), Mathf.Clamp(transform.localScale.y, 1.0f, 6.0f), Mathf.Clamp(transform.localScale.z, 1.0f, 6.0f));
    }


}
