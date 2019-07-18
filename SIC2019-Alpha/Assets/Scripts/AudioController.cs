﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource HatOpenSource, SnareSource, KicksSource, HatClosedSource;
    //public AudioClip HatOpen, Snare, Kick, HatClosed;

    // Start is called before the first frame update
    void Start()
    {
        
        InputManager.OnPushKicks += PlayKick;
        InputManager.OnPushHatsC += PlayHatsC;
        InputManager.OnPushHatsO += PlayHatsO;
        InputManager.OnPushSnares += PlaySnares;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayKick()
    {
        KicksSource.Play();
    }

    private void PlaySnares()
    {
        SnareSource.Play();
    }

    private void PlayHatsO()
    {
        HatOpenSource.Play();
    }

    private void PlayHatsC()
    {
        HatClosedSource.Play();
    }
}
