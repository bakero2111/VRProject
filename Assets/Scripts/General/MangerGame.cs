using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MangerGame : MonoBehaviour
{
    [Header("GANAR")]
    public GameObject Enemigo1;
    public GameObject EnemigoText1;
    public Animator BossAnim1;
    public Material Desinte1;
    public GameObject Enemigo2;
    public GameObject EnemigoText2;
    public GameObject CabezaText2;
    public GameObject CuernosText2;
    public Animator BossAnim2;
    public Material Desinte2;

    [Header("Luego De Ganar")]
    public GameObject PantallaGanar;

    [Header("Hora")]
    bool ContadorPrendido=true;
    public float TiempoTotal;
    public float tiempoGuardado;
    public List<GameObject> VelasHorario;
    int Hora;
    private void Start()
    {
        tiempoGuardado = TiempoTotal;
        ContadorPrendido = true;
        TiempoTotal = tiempoGuardado / 12;
    }
    private void FixedUpdate()
    {
        if(ContadorPrendido)
        {
            TiempoTotal -= Time.deltaTime;
        }
        if(TiempoTotal <= 0 && VelasHorario[VelasHorario.Count-1].activeSelf)
        {
            ApagarVela();
            TiempoTotal = tiempoGuardado / 12;
        }
        else if(!VelasHorario[VelasHorario.Count - 1].activeSelf&& ContadorPrendido)
        {
            MatarEnemigoFin();
            ContadorPrendido = false;
            
        }
    }
    public void ApagarVela()
    {
        VelasHorario[Hora].SetActive(false);
        Hora++;
    }
    public void MatarEnemigoFin()
    {
        //Enemigo1.GetComponent<DañoLuz>().IniciarDanho();
        Enemigo1.GetComponent<NavMeshAgent>().speed = 0.15f;
        Enemigo2.GetComponent<NavMeshAgent>().speed = 0.15f;
        EnemigoText1.GetComponent<SkinnedMeshRenderer>().material = Desinte1;
        EnemigoText2.GetComponent<SkinnedMeshRenderer>().material = Desinte2;
        CabezaText2.GetComponent<SkinnedMeshRenderer>().material = Desinte2;
        CuernosText2.GetComponent<SkinnedMeshRenderer>().material = Desinte2;
        BossAnim1.SetTrigger("Morir");
        BossAnim2.SetTrigger("Morir");

        StartCoroutine(Ganar());
        
    }
    IEnumerator Ganar()
    {
        EnemigoText1.GetComponent<Animator>().enabled = true;
        EnemigoText2.GetComponent<Animator>().enabled = true;
        CabezaText2.GetComponent<Animator>().enabled = true;
        CuernosText2.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3.5f);
        Enemigo1.SetActive(false);
        Enemigo2.SetActive(false);
        yield return new WaitForSeconds(2);
        PantallaGanar.SetActive(true);
    }
    
}
