using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{


    public bool StateCollision = false;


    public float PicthState = 1.5f;

    public float speed;

    AudioSource AudioSourceEngineSound;

    AudioSource AudioSourceCrashSound;

    public AudioClip EngineSound;

    public AudioClip CrashSound;
   
    
    void Start()
    {

        AudioSourceEngineSound = GetComponent<AudioSource>();
        AudioSourceEngineSound.clip = EngineSound;
        AudioSourceEngineSound.Play();

        AudioSourceCrashSound = GetComponent<AudioSource>();
        AudioSourceCrashSound.clip = CrashSound;

    }

    // Update is called once per frame
    void Update()
    {

        speed = transform.GetComponent<CarController>().speed;
       //float  vertical = transform.parent.GetComponent<CarController>()._vertical;
        speed = speed / 50;




        //audio.clip = EngineSound;

        AudioSourceEngineSound.pitch = PicthState + speed;// * vertical;



        if (StateCollision)
        {
            print("crash");


            StateCollision = false;
            
           // AudioSourceCrashSound.Play();


        }


    }

}
