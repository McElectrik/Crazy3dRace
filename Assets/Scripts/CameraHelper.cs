using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraHelper: MonoBehaviour
{

    public Transform target; // обьект за которым нужно следить

    public float smooth = 2f;

    public Vector3 offset = new Vector3 (1, 2, 1);

    void Start()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth); // положение камеры


        transform.LookAt(target); // поворачиваем обьект на цель 
    

    }


    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth); // положение камеры


        transform.LookAt(target); // поворачиваем обьект на цель 

    }
}
