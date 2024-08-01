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
        if(!SimbolosObj[instanciaSimbolo].activeSelf && instanciaSimbolo<SimbolosObj.Count-1){
            DonGM.ApagarVela();
            SimbolosObj[instanciaSimbolo+1].SetActive(true);
            instanciaSimbolo++;
            
        }
        else if(instanciaSimbolo>=SimbolosObj.Count-1){
            DonGM.ApagarVela();
            instanciaSimbolo=1;
            SimbolosObj[instanciaSimbolo].SetActive(true);
        }
    }
    public void IniciarJuego()
    {
        LuzIinicio.StartCoroutine(LuzIinicio.Secuencia());
    }
}
