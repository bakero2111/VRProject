using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunaAObjetivo : MonoBehaviour
{
    public RunaGM RunaMaster;
    public List<GameObject> Objetivos = new List<GameObject>();
    int NumObjetivo = 0;
    public bool RecorridoFinalizado = false;
    public GameObject Seguidor;
    public float VelMovSeguidor;
    GameObject UltObjetivoxd;
    public GameObject ParicMagic;
    public GameObject ColisionesGen;
    void AlcanzadosObj()
    {
        
        if(Objetivos.Count == NumObjetivo+1) // en caso de que solo sea un punto objetivo
        {
            this.GetComponent<BoxCollider>().enabled = false;
            Objetivos[0].GetComponent<MeshRenderer>().enabled = false;
            Objetivos[0].GetComponent<BoxCollider>().enabled = false;
            RecorridoFinalizado =true;
            SeguimientoFeedBack();
            //StartCoroutine(EmpezarBucle());
            //this.gameObject.SetActive(false);
            UltObjetivoxd.SetActive(false);
            RunaMaster.SubirPunto();
            this.gameObject.SetActive(false);
            
        }
        else if(Objetivos.Count >= 2 && Objetivos.Count != NumObjetivo + 1) // en caso de que hayan dos objetivos a mas
        {
            //Objetivos[NumObjetivo].SetActive(false);
            Objetivos[NumObjetivo].GetComponent<MeshRenderer>().enabled = false;
            Objetivos[NumObjetivo].GetComponent<BoxCollider>().enabled=false;
            NumObjetivo++;
            Objetivos[NumObjetivo].SetActive(true);
        }
    }
    void SeguimientoFeedBack()
    {
        /*
        for(int i = 0; i < Objetivos.Count;i++)
        {
            Seguidor.transform.DOMove(Objetivos[i].transform.position, VelMovSeguidor)
                .OnComplete(() => Debug.Log("llego Al Move"));
            
        }
        */

        Vector3[] puntosDeCamino = Objetivos.Select(obj => obj.transform.position).ToArray();
        Seguidor.transform.DOPath(puntosDeCamino, VelMovSeguidor, PathType.Linear);
    }
    public void RegresarAlParent()
    {
        this.transform.parent = RunaMaster.transform.parent;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Runa/Objetivo")
        {
            if (Objetivos.Count == NumObjetivo + 1)
            {
                UltObjetivoxd = collision.gameObject;
            }

            AlcanzadosObj();
        }   
    }
    public void ActivarCamino()
    {
        ParicMagic.SetActive(true);
        ColisionesGen.SetActive(true);
        Objetivos[NumObjetivo].SetActive(true);
    } //SE ACTIVA TODA PREVISUALIZACION PARA SEGUIR EL CAMINO
    public void DesactivarCamino()
    {
        //ParicMagic.SetActive(false);
        ColisionesGen.SetActive(false);
        Objetivos[NumObjetivo].SetActive(false);
    }
}
