using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel; // коллайдеры
    public WheelCollider rightWheel; // колес
    public bool motor;  // вращение колес
    public bool steering; // повороты колес
	public bool brake; // ручной тормоз
}
         
public class CarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque; //мах вращение 
    public float maxSteeringAngle; // мах угол поворота колес
	public float maxbrake; // тормоз
    float timeReset; // Время после которого будет следующий ремонт
 

   public bool _reset; //  ремонт
   public bool _brake; //  ручник 
    bool flagreset; // флаг ResetCar()

    public float _vertical; // вперед назад
   public float _horizontal; // влево вправо

    //Vector3 OldTranfsorm; //старые координаты
    public int speed; //скорость машины
    float dist; //расстояние пройденое за время
                //public float _Rpm;
                //public float _Speed2;

   public int GameState; // состояние игры 0-game over   1 - game

    GameObject GameHelper;// ссылка на обьект

    int gameover = 0;
    int game = 1;

    Rigidbody rb;

    
    
        

   
        
    
    void Start()
    {
        
        Screen.sleepTimeout = SleepTimeout.NeverSleep;  //экран не будет гаснуть

        rb = GetComponent<Rigidbody>();

         GameHelper = GameObject.Find("GameHelper"); // ссылка на GameHelper


        // GameState = GameHelper.GetComponent<GameHelper>().GameState;
        //print(GameState);
        // GameState = GameState;

      

    }



    public void ApplyLocalPositionToVisuals(WheelCollider collider) // нахождение визуальных колес и манипулирование ими
    {
        if (collider.transform.childCount == 0) {
            return;
        }
         
        Transform visualWheel = collider.transform.GetChild(0);
         
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
         
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
         
		 
		 
	
		 
		 
     void FixedUpdate()  // Код управления машиной
     {

        UpdateSpeed(); // метод вычисления скорости
        

       

            if (GameState == gameover)
            {
                _vertical = 0;
                _horizontal = 0;
                _brake = true;

            }
            else
            {
                //_brake = false;


            }

            float motor = maxMotorTorque * _vertical; // ускорение
            float steering = maxSteeringAngle * _horizontal; // поворот колес



            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;


                }

                if (axleInfo.brake)
                {
                    if (_brake)
                    {
                        axleInfo.leftWheel.brakeTorque = maxbrake;
                        axleInfo.rightWheel.brakeTorque = maxbrake;
                    }
                    else
                    {
                        axleInfo.leftWheel.brakeTorque = 0;
                        axleInfo.rightWheel.brakeTorque = 0;
                    }
                }

                //_Rpm = axleInfo.rightWheel.rpm; // округление и перевод в int

                ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                ApplyLocalPositionToVisuals(axleInfo.rightWheel);

            }


         

    }



    void Update()

    {


        GameState = GameHelper.GetComponent<GameHelper>().GameState;  // получаем состояние игры 
        // _Rpm = Mathf.FloorToInt(_Rpm);


        if (transform.position.y < -5) // если машина упала за карту

        {

            transform.position = new Vector3(200, 1, 290); // возвращаем обьект на карту

        }


        if (tag == "Player") // если это пользователь проверяем кнопки

        {
            PlayerCarControl();

        }



        if (speed < 1) ResetCar(); // если скорость = 0 то разрешаем  ремонт

        if (speed > 10)
        {
            if (_vertical == -1)
            {
                _vertical = 0;
            }
        }
        
/*
        if (GameState == gameover)
        {
            _vertical = 0; 
            _horizontal = 0;
            _brake = true;

        }
        else
        {
            _brake = false;
        }
    
        */

    }
	   
	



   



  public  void PlayerCarControl()
    {


        
        _vertical = Input.GetAxis("Vertical"); // нажата "вверх или вниз "   

      // _vertical = Input.acceleration.y;

       _horizontal = Input.GetAxis("Horizontal"); // нажата "вправо или влево " 

       // _horizontal = Input.acceleration.x;

        _brake = Input.GetButton("Jump");  // нажата " пробел "

        //_reset = Input.GetKey("R"); //  нажата R  то ремонт машины

        _reset = Input.GetKeyUp(KeyCode.R); //  нажата R  то ремонт машины


        /*/ремонт

        int AngleObjectZ = Mathf.FloorToInt(transform.eulerAngles.z); // если машина 

            AngleObjectZ = 400 - AngleObjectZ; // кренится




            _reset = 340 > AngleObjectZ && AngleObjectZ > 100 ? true : false; //_reset = true; // ставим машину на колеса 

            // _reset = false; // иначе машина на колесах
       /*/











    }


    void ResetCar()
    {
        if (_reset  && !flagreset)
        {

            flagreset = true;

            timeReset = Time.time + 3; // + 3 сек

            

        }



        if (flagreset)
        {
            

            if (Time.time > timeReset)  // машина ставится на колеса только после 3 сек
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0); // машина ставится на колеса

                flagreset = false;

                
            }
        }


       
    }

  
        

   void UpdateSpeed()
    {
        /*dist = Vector3.Distance(OldTranfsorm, transform.position); // расстояние пройденое за 0,02 сек
        dist = dist * 180; // расстояние пройденое в км/ч
        speed = Mathf.FloorToInt(dist); // округление и перевод в int
        OldTranfsorm = transform.position; // сохранение старых координат
    */

        speed = Mathf.FloorToInt(rb.velocity.magnitude * 3.6f); // округление и перевод в int
    }


   
   

}