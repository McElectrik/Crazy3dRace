using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{


 public float PicthState = 1.5f;
    public float speed;
    AudioSource audio;
    public AudioClip EngineSound;
    

    // Start is called before the first frame update
    void Start()
    {

        audio = GetComponent<AudioSource>();
        audio.clip = EngineSound;
        audio.Play();

        
    }

    // Update is called once per frame
    void Update()
    {

        speed = transform.parent.GetComponent<CarController>().speed;
       //float  vertical = transform.parent.GetComponent<CarController>()._vertical;
        speed = speed / 50;
        audio.pitch = PicthState + speed;// * vertical;


        
    }

}
