using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UICarHelper : MonoBehaviour
{
    
    // вывод в канвас
    public Text print_speed;  // скорость
    public Text print_dlina;  // расстояние до цели
    public Text print_score;  // очки игрока 
    public Text print_scoreBot_0;   // очки 
    public Text print_scoreBot_1;    // 
    public Text print_scoreBot_2;    //  ботов

    

    public Transform [] Bots; // массив ботов
    


    int speed;              //скорость машины
    int dlina;              //дистанция
    int score ;             // очки
    Vector3 OldTranfsorm;   //старые координаты
    float dist;              //расстояние пройденое за время
    public Transform target; // Цель

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
       
        speed = GetComponent<CarController>().speed; // получаем скорость машины

        dist = Vector3.Distance(transform.position, target.transform.position);
        dlina = Mathf.FloorToInt(dist);
        

        print_speed.text = speed.ToString() + " Km/h"; // пишем в канвас
                                                       
        print_dlina.text = dlina.ToString() + " m"; // пишем в канвас

        score = GetComponent<PlayerHelper>().Score;      

        print_score.text = "Player  " + score.ToString();    // очки игрока


        score = Bots[0].GetComponent<PlayerHelper>().Score;

        print_scoreBot_0.text = Bots[0].name + " "+ score.ToString();   //очки ботов


        score = Bots[1].GetComponent<PlayerHelper>().Score;

        print_scoreBot_1.text = Bots[1].name +" "+ score.ToString();    //очки ботов


        score = Bots[2].GetComponent<PlayerHelper>().Score;

        print_scoreBot_2.text = Bots[2].name +" "+ score.ToString();    //очки ботов


    }
}
