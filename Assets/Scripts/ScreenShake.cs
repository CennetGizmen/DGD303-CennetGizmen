using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float timer;

    private CinemachineBasicMultiChannelPerlin _cmbmcp;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera(float amplitude, float duration)
    {

        CinemachineBasicMultiChannelPerlin _cmbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _cmbmcp.m_AmplitudeGain = amplitude;
        timer = duration;


    }

    void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cmbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cmbmcp.m_AmplitudeGain = 0;

        timer = 0;
    }

    private void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;

            if(timer<=0)
            {
                StopShake();
            }


        }
    }




}
