using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimbolMaster : MonoBehaviour
{
    public List<GameObject> SimbolosObj;
    int instanciaSimbolo;

    // Update is called once per frame
    public void ActivarSiguienteSimbolo()
    {
        if(SimbolosObj[instanciaSimbolo] !=null && instanciaSimbolo<SimbolosObj.Count){
            SimbolosObj[instanciaSimbolo+1].SetActive(true);
            instanciaSimbolo++;
        }
    }
}
