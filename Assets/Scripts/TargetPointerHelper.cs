using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointerHelper : MonoBehaviour
{


    public Transform targetBot;
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetBot);
        

    }
}
