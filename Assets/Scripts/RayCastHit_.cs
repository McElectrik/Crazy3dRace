using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHit_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RayCastHit__()
    {
        RaycastHit hitleft;
        RaycastHit hitright;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitleft, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitleft.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            hitleft.distance = 10;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitleft.distance, Color.white);
            //Debug.Log("Did not Hit");
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitright, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitright.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }
        else
        {
            hitright.distance = 10;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.white);
            //Debug.Log("Did not Hit");
        }


/*
        if (hitleft.distance > hitright.distance)
        {

            horizontal = left; // влево

        }
        else if (hitleft.distance < hitright.distance)
        {

            horizontal = right; // вправо

        }
        // else
        // FindTarget(); // режим 0 основной

        if (Mode == 0 && speed < 2)

        {
            //  Mode = 2;

            //  TimeMode = Time.time + 2;
        }

    */
    }





}
