using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCarControl : MonoBehaviour
{
    // bool _collision; // столкновение
    //bool _flagcollision; // flag коллайдера

    // bool flagreset; // флаг  ремонт

    //public Transform LeftRayCast; //ссылка на левый RayCast 
   // public Transform RightRayCast; //ссылка на правый RayCast 

    public Transform TargetPointer; // ссылка на целеуказатель

    int AngleRotateTargetPointer; // угол поворота целеуказателя
    int AngleRotateObject; // угол поворота обьекта
    int Angle; // разница между углами 
    public int AngleStatic; // предел угла
    //public bool _player;

    public int Mode; // выбор режима

    float vertical; // вперед назад
    float horizontal; // влево вправо
    public bool _reset; //  ремонт

    float TimeMode; // время работы режима
    int speed; //скорость машины

    int left = - 1 , right = 1; // влево вправо


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        speed = GetComponent<CarController>().speed; // получаем скорость машины

        if (Time.time > TimeMode)  // если время вышло
        {
            switch (Mode) // выбирай режим
            {
                case 0:
                    FindTarget(); // режим 0 основной
                    break;



                case 1:
                       CollisionMoveCar(); // режим 1 столкновение с машиной при движении
                    break;



                case 2:
                    CollisionStopCar(); // режим 2 столкновение  с остановкой
                    break;
            }

        }





        
        BotReset(); // ремонт 

        GetComponent<CarController>()._vertical = vertical; // передаем вперед назад

        GetComponent<CarController>()._horizontal = horizontal; // передлаем влево вправо

        GetComponent<CarController>()._reset = _reset; // ремонт 

        GetComponent<CarController>()._brake = false;

        if (Time.time > TimeMode) Mode = 0;  // если время вышло  поиск цели

    }


   void OnCollisionStay(Collision collis)  //  столкновения с чем либо

    {

        if (Time.time > TimeMode)  // если время вышло 
        {
            if (speed > 2)  // машина движется
            {
                Mode = 1;  // режим 1

            }
            else  // иначе 
            {
                Mode = 2;   //режим 2

            }

            TimeMode = Time.time + Random.Range(1, 4);  // случайно время режима

            // print(name + " collision  =  " + collis.collider.name );

        }
    }
    
    void FindTarget()  // режим поиска цели
    {

        vertical = 1; // Боты всегда вперед

        AngleRotateTargetPointer = Mathf.FloorToInt(TargetPointer.transform.eulerAngles.y); // угол Y указателя цели

        AngleRotateObject = Mathf.FloorToInt(transform.eulerAngles.y); // угол Y машины

        Angle = AngleRotateTargetPointer - AngleRotateObject; // разница между углами 


        if (Angle > AngleStatic) // если угол больше установленного
        {
            horizontal = right; //вправо

        }
        else if (Angle < - AngleStatic)  // если угол меньше установленного
        {
            horizontal = left; // влево

        }
        else
        {

            horizontal = 0;  // иначе прямо

        }

    }




    void CollisionMoveCar()  //mode 1
    {
        // horizontal = Random.Range(-1, 2);

        horizontal = horizontal * (-1); // выворачиваем колеса в обратную сторону
        vertical = 0; // сбрасываем газ

        //print(" столкновение ");
        //print(horizontal);

    }



    void CollisionStopCar() //mode 2
    {

        horizontal = horizontal * (-1);  // выворачиваем колеса в обратную сторону

        vertical = vertical * (-1);   // едим в обратную сторону

    }


    void BotReset() // ремонт
    {

        int AngleObjectZ = Mathf.FloorToInt(transform.eulerAngles.z); // если машина 

        AngleObjectZ = 400 - AngleObjectZ; // кренится


       

        _reset = 340 > AngleObjectZ && AngleObjectZ > 100 ? true : false; //_reset = true; // ставим машину на колеса 

                                                                          // _reset = false; // иначе машина на колесах
    }











}
