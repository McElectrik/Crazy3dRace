using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGateHelper : MonoBehaviour
{
    
    Color colorGate; //  цвет фонаря на воротах

    public bool TargetState; // состояние ворот (яв. ли целью или нет)

    void Start()
    {
        
    }

   
    void Update()
    {
        if (TargetState == false)   // если не яв целью 

            colorGate = Color.red; // фонари красные

        else                       // если яв целью 

            colorGate = Color.green; // иначе зеленые


        for (int i = 0; i < 3; i++) // все 3 фонаря 
            {
                Transform _getchild = transform.GetChild(i);
                _getchild.GetComponent<Renderer>().material.color = colorGate;
            }


    }


 
    private void OnTriggerExit(Collider other)  // если в воротах 
    {
        //Debug.Log(" Object = " + other);

        
            if (other.tag == "Player" || other.tag == "Bot") //  какой то игрок

            if (TargetState == true)  // и ворота true
            {
           
            colorGate = Color.red;  // фонари красные

            other.GetComponent<PlayerHelper>().Score ++;  // игроку  добавь очко

            //TargetState = false;

            Transform _getparent = transform.parent;
            _getparent.GetComponent<GateHelper>().targetState = false; // ворота не яв. целью





        }
        
    }

}


