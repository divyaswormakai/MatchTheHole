using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    bool move = false;
    float speed = 5f;
 
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        pos.x -= speed * Time.deltaTime;

        if (pos.x <= -25f)
        {
            pos.x = 42f;
        }
        GetComponent<Transform>().position = pos;
    }
}
