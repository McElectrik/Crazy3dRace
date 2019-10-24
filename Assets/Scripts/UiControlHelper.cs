using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiControlHelper : MonoBehaviour
{

    public int _AxisVertical;

    public int _AxisHorizontal;

    public bool _Reset;

    bool _Brake; //  ручник 

    private void Start()
    {
        //_AxisVertical = 1;
    }


    // Update is called once per frame
    void Update()

    {
        

        GetComponent<CarController>()._vertical = _AxisVertical; // передаем вперед назад 

        GetComponent<CarController>()._horizontal = _AxisHorizontal; // перелаем влево вправо

        GetComponent<CarController>()._reset = _Reset; // ремонт 

        GetComponent<CarController>()._brake = _Brake; // ремонт 



        //print(_AxisVertical);
    }

    public void MoveCar(int AxisVertical)
    {

        _AxisVertical = AxisVertical;

        //print(AxisVertical);

    }

    public void RotateCar(int AxisHorizontal)
    {


        _AxisHorizontal = AxisHorizontal;

    }



    public void BrakeCar(bool Brake)
    {

        _Brake = Brake;


    }

    public void ResetCar(bool Reset)
    {

        _Reset = Reset;


    }

}
