using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class TargetControl : MonoBehaviour
{
    public Transform target; // Цель за кем следить
	
	
   
   

   
    void Update()
    {
     transform.LookAt(target);   // поворачиваем обьект на цель 
    }
}
