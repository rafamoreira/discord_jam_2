﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatRetriever : MonoBehaviour
{
    MusicBuffer mb;
    float timer;

    public bool play_audio;
    bool toogle_change = true;
    
    public AudioSource audio_source;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 15;
        mb = FindObjectOfType<MusicBuffer>();
        timer = 4.5f;
	play_audio = false;
	light.SetActive(false);
    }

    void Update()
    {
        if (timer > 0)
           timer -= Time.deltaTime; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer <= 0)
        {
	    play_audio = true;
            if (mb.RetrieveBeat()){
		light.SetActive(true);
	    }
	    else{
		light.SetActive(false);
	    }
        }

	 if (play_audio && toogle_change)
	 {
		audio_source.Play();
		toogle_change = false;
	 }

    }
}
