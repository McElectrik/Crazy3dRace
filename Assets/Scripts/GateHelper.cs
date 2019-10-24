using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHelper : MonoBehaviour
{
    // Start is called before the first frame update

   
   
    public  bool targetState = false;  // состояние ворот (яв. ли целью или нет)

    

    // Update is called once per frame
    void Update()
    {

        Transform _getchild = transform.GetChild(3);
        

        _getchild.GetComponent<TriggerGateHelper>().TargetState = targetState; // получаем у дочернего обьекта  статус ворот


    }



}

