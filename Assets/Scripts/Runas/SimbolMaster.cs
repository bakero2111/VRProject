using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimbolMaster : MonoBehaviour
{
    public List<GameObject> SimbolosObj;
    int instanciaSimbolo;
    public flashaltoque LuzIinicio;
    public MangerGame DonGM;

    // Update is called once per frame
    public void ActivarSiguienteSimbolo()
    {
        if(SimbolosObj[instanciaSimbolo] !=null && instanciaSimbolo<SimbolosObj.Count-1){
            DonGM.ApagarVela();
            SimbolosObj[instanciaSimbolo+1].SetActive(true);
            instanciaSimbolo++;
            
        }
    }
    public void IniciarJuego()
    {
        LuzIinicio.StartCoroutine(LuzIinicio.Secuencia());
    }
}
