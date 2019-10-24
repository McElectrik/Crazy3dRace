using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform [] gate;  // массив ворот

                  int NgateOld, Ngate; // номер старых и новых ворот

    public GameObject _Tag;  // цель

    void Start()
    {
        Ngate = Random.Range(0, gate.Length); //  случайный номер ворот

        gate[Ngate].GetComponent<GateHelper>().targetState = true; // ставим статус воротам

        _Tag.transform.position = gate[Ngate].transform.position;  // цель  помещаем в выбранные ворота

    }

    // Update is called once per frame
    void Update()
    {
        if (gate[Ngate].GetComponent<GateHelper>().targetState == false)  // если выбранные ворота не активны 
        {
            do
            {
                Ngate = Random.Range(0, gate.Length); // выбираем новые ворота
            }

            while (Ngate == NgateOld) ;


                gate[Ngate].GetComponent<GateHelper>().targetState = true; // ставим статус воротам

            _Tag.transform.position = gate[Ngate].transform.position;  // цель  помещаем в выбранные ворота

            NgateOld = Ngate; // что бы ни выбрать эти ворота опять
        }
    }
    


   // void OnGUI()
   // {
   //     GUI.Label(new Rect(Screen.width - 100, 10, 40, 40), _gate.ToString());
   // }


}
