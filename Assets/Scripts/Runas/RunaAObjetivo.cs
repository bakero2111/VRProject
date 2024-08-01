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
    [Header("Señalizacion")]
    public GameObject Flecha;
    public float MaxDistancia;
    [Header("FeedBack")]
    public GameObject particula_Explotion;
    public AudioClip tink;
    AudioSource Sonido;
    // si se lo lleva lejos
    Vector3 PosInicial;
    bool FirstTimer=false;
    void OnEnable(){
        if(FirstTimer){
        this.gameObject.transform.position= PosInicial;
        }
    }
    public void Start()
    {
        Sonido=RunaMaster.GetComponent<AudioSource>();
        if(!FirstTimer){
        PosInicial = this.transform.position;
        }
        NumObjetivo = 0;
        
        Flecha.transform.forward = Objetivos[NumObjetivo].transform.position - Flecha.transform.position;

        if(FirstTimer){
        this.gameObject.transform.position= PosInicial;
        }
    }
    
    void AlcanzadosObj()
    {
        
        if(Objetivos.Count == NumObjetivo+1) // en caso de que solo sea un punto objetivo
        {
            RunaMaster.SubirPunto();
            //this.GetComponent<BoxCollider>().enabled = false;
            //Objetivos[0].GetComponent<MeshRenderer>().enabled = false;
            //Objetivos[0].GetComponent<BoxCollider>().enabled = false;
            Objetivos[0].SetActive(false);
            RecorridoFinalizado =true;
            SeguimientoFeedBack();
            UltObjetivoxd.SetActive(false);
            this.gameObject.SetActive(false);
            Instantiate(particula_Explotion, transform.position, Quaternion.identity);
            FirstTimer=true;
        }
        else if(Objetivos.Count >= 2 && Objetivos.Count != NumObjetivo + 1) // en caso de que hayan dos objetivos a mas
        {
            Flecha.transform.forward = Objetivos[NumObjetivo].transform.position - Flecha.transform.position;
            //Objetivos[NumObjetivo].GetComponent<MeshRenderer>().enabled = false;
           // Objetivos[NumObjetivo].GetComponent<BoxCollider>().enabled=false;
           Objetivos[NumObjetivo].SetActive(false);
            NumObjetivo++;
            Objetivos[NumObjetivo].SetActive(true);
            Flecha.GetComponent<FlechaFeed>().ObjetivoFlecha = Objetivos[NumObjetivo];
            Instantiate(particula_Explotion, transform.position, Quaternion.identity);
        }
    }
    void SeguimientoFeedBack()
    {

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
            Sonido.PlayOneShot(tink);
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
        Flecha.GetComponent<FlechaFeed>().enabled = true;
       Flecha.GetComponent<FlechaFeed>().ObjetivoFlecha= Objetivos[NumObjetivo];
    } //SE ACTIVA TODA PREVISUALIZACION PARA SEGUIR EL CAMINO
    public void DesactivarCamino()
    {
        Flecha.GetComponent<FlechaFeed>().enabled = false;
        //ParicMagic.SetActive(false);
        ColisionesGen.SetActive(false);
        Objetivos[NumObjetivo].SetActive(false);
        if (Vector3.Distance(this.transform.position, PosInicial) > MaxDistancia)
        {
            this.transform.position = PosInicial;
        }
    }
}
