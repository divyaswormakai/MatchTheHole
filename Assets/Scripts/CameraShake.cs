using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("ASDF");
            CameraShaker.GetInstance("CineCam").ShakeOnce(10f, 5f, 0.1f, 0.1f);
        }
    }
}
