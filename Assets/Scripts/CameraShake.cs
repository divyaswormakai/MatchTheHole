using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    public float duration = 1.5f;
    public float amplitude = 3.5f;
    public float frequency = 3f;

    private float elapsedTime = 0f;
    private float defaultAmplitude = 0.5f;
    private bool shakeBool = false;

    public CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin vCamNoise;

    void Start()
    {
        if(vCam != null)
        {
            vCamNoise = vCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        } 
    }

    // Update is called once per frame
    void Update()
    {

        if (shakeBool)
        {
            if (elapsedTime > 0)
            {
                vCamNoise.m_AmplitudeGain = amplitude;
                vCamNoise.m_FrequencyGain = frequency;

                elapsedTime -= Time.deltaTime;
            }
            else
            {
                vCamNoise.m_AmplitudeGain = defaultAmplitude;
                elapsedTime = 0;
                shakeBool = false;
            }
        }
      
    }

    public void GameOverShake()
    {
        shakeBool = true;
        elapsedTime = duration;
    }
}
