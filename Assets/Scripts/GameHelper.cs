using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameHelper : MonoBehaviour
{


    AudioSource audio;

    public AudioClip StartSound;

    public Text Print_Info;  // инфа об игре

    public int GameState = 0; // состояние игры 0-game over      1 - game

    public Transform [] gate;  // массив ворот

    int NgateOld, Ngate; // номер старых и новых ворот

    public GameObject _Tag;  // цель

    //public int count = 0;

        int game = 1;

    void Start()

    { 
       
        Ngate = UnityEngine.Random.Range(0, gate.Length); //  случайный номер ворот

        gate[Ngate].GetComponent<GateHelper>().targetState = true; // ставим статус воротам

        _Tag.transform.position = gate[Ngate].transform.position;  // цель  помещаем в выбранные ворота

        StartCoroutine(StartGame());

        audio = GetComponent<AudioSource>();
        audio.clip = StartSound;
        //audio.Play();

    }


    IEnumerator StartGame()
    {
        for (int count = 1; count < 5 ; count++)
       {           
            
            yield return new WaitForSeconds(1);
            audio.Play();
            Print_Info.text = count.ToString();
        }
        
        Print_Info.text = "Поехали!";

        GameState = game;

        StartCoroutine(Clear_Info());
    }



    IEnumerator Clear_Info()
    {

        yield return new WaitForSeconds(1);

        Print_Info.text = "";
    }





    void Update()
    {


        
        if (gate[Ngate].GetComponent<GateHelper>().targetState == false)  // если выбранные ворота не активны 
        {
            do
            {
                Ngate = UnityEngine.Random.Range(0, gate.Length); // выбираем новые ворота
            }

            while (Ngate == NgateOld) ;


                gate[Ngate].GetComponent<GateHelper>().targetState = true; // ставим статус воротам

            _Tag.transform.position = gate[Ngate].transform.position;  // цель  помещаем в выбранные ворота

            NgateOld = Ngate; // что бы ни выбрать эти ворота опять
        }
    }
  

    

    // void OnGUI()
    // {
    //     GUI.Label(new Rect(Screen.width - 100, 10, 40, 40), _gate.ToString());
    // }


}
