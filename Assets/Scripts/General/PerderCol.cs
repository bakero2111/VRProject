using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerderCol : MonoBehaviour
{
    [Header("Oportunidades")]
    public List<GameObject> Velas = new List<GameObject>();
    public List<GameObject> FinJuego;
    int Vez;
    int Oportunidades;
    bool Perdida=false;
    [Header("Monstruo1")]
    public GameObject Monstruo1;
    public Transform PosInicial;
    [Header("Monstruo2")]
    public GameObject Monstruo2;
    public Transform PosInicial2;
    [Header("Jugador")]
    public GameObject JugadorCompleto;
    public GameObject Transicion_Jugador;
    public float VelTransicion;
    public AudioListener MicroPrincipal;
    public AudioListener Sala1Micro;
    public AudioListener Sala2Micro;
    public AudioListener Sala3Micro;
    public Transform PosInicialaea;
    [Header("sala1")]
    public GameObject CuartoBoss1;
    public Transform Pos1Sala;
    public GameObject Sala1Transicion;
    [Header("sala2")]
    public GameObject CuartoBoss2;
    public Transform Pos2Sala;
    public GameObject Sala2Transicion;
    [Header("salaPerderFinal")]
    public GameObject CuartoPerderFinal;
    public Transform PosFinalSala;
    public GameObject PantallaPerder;
    public GameObject SimbolosTotalesParent;
    private void Start()
    {
        Vez = Velas.Count;
    }
    
    public void PerderMonster1()
    {
        if (Oportunidades < Vez && !CuartoBoss1.activeSelf && !CuartoBoss2.activeSelf)
        {
            Monstruo2.GetComponent<DañoLuz>().IniciarDanho();
            StartCoroutine(TransicionCuarto1());
        }
        else if (Oportunidades >= Vez && !Perdida && !CuartoBoss1.activeSelf && !CuartoBoss2.activeSelf)
        {
            Perdida = true;
            StartCoroutine(TransicionFinalPerder());
        }
    }
    
    public void PerderMonster2()
    {
        if (Oportunidades < Vez && !CuartoBoss1.activeSelf&&!CuartoBoss2.activeSelf)
        {
            Monstruo1.GetComponent<DañoLuz>().IniciarDanho();
            StartCoroutine(TransicionCuarto2());
        }
        else if(Oportunidades >= Vez && !Perdida && !CuartoBoss1.activeSelf && !CuartoBoss2.activeSelf)
        {
            Perdida = true;
            
            StartCoroutine(TransicionFinalPerder());
        }
    }
    void ApagarVela()
    {
        if (Oportunidades < Vez)
        {
            //VelasHorario[Hora].GetComponent<ApagarVela>().StartCoroutine(VelasHorario[Hora].GetComponent<ApagarVela>().SecuenciaApagar());
            Velas[Oportunidades].GetComponent<ApagarVela>().StartCoroutine(Velas[Oportunidades].GetComponent<ApagarVela>().SecuenciaApagar());
            Oportunidades++;
        }
        
    }
    public void FinJuegoApagar()
    {
        for (int i = 0; i < FinJuego.Count; i++)
        {
            FinJuego[i].gameObject.SetActive(true);
        }
    }
    IEnumerator TransicionCuarto1()
    {
       // MicroPrincipal.enabled = false;
        Transicion_Jugador.SetActive(true);
        
        yield return new WaitForSeconds(0.2f);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        JugadorCompleto.transform.position= Pos1Sala.position;
        CuartoBoss1.SetActive(true);
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
         yield return new WaitForSeconds(1f);
         Transicion_Jugador.SetActive(false);
        yield return new WaitForSeconds(2f);
        Transicion_Jugador.SetActive(true);
        JugadorCompleto.transform.position= PosInicialaea.position;
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2.8f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4.5f;
        yield return new WaitForSeconds(0.2f);
        CuartoBoss1.SetActive(false);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        ApagarVela();
        yield return new WaitForSeconds(0.4f);
        MicroPrincipal.enabled = true;
        Transicion_Jugador.SetActive(false);
        
    }
    IEnumerator TransicionCuarto2()
    {
        //MicroPrincipal.enabled = false;
        Transicion_Jugador.SetActive(true);
       
        yield return new WaitForSeconds(0.2f);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        JugadorCompleto.transform.position= Pos2Sala.position;
        CuartoBoss2.SetActive(true);
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
         yield return new WaitForSeconds(1f);
         Transicion_Jugador.SetActive(false);
        yield return new WaitForSeconds(2f);
        
        JugadorCompleto.transform.position= PosInicialaea.position;
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2.8f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4.5f;
        yield return new WaitForSeconds(0.2f);
        ApagarVela();
        Transicion_Jugador.SetActive(true);
        CuartoBoss2.SetActive(false);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        yield return new WaitForSeconds(0.4f);
        MicroPrincipal.enabled = true;
        Transicion_Jugador.SetActive(false);
    }
    IEnumerator TransicionFinalPerder()
    {
        Transicion_Jugador.SetActive(true);
        //MicroPrincipal.enabled = false;
        yield return new WaitForSeconds(1f);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        CuartoPerderFinal.SetActive(true);
        JugadorCompleto.transform.position= PosFinalSala.position;
        Monstruo1.SetActive(false);
        Monstruo2.SetActive(false);
        yield return new WaitForSeconds(1f);
         Transicion_Jugador.SetActive(false);
        yield return new WaitForSeconds(2f);
        PantallaPerder.SetActive(true);
        Transicion_Jugador.SetActive(true);
        JugadorCompleto.transform.position= PosInicialaea.position;
        yield return new WaitForSeconds(0.2f);
        CuartoPerderFinal.SetActive(false);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        yield return new WaitForSeconds(0.4f);
        //MicroPrincipal.enabled = true;
        FinJuegoApagar();
        Transicion_Jugador.SetActive(false);
        SimbolosTotalesParent.SetActive(false);
    }
}
