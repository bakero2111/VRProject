using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerderCol : MonoBehaviour
{
    [Header("Oportunidades")]
    public List<GameObject> Velas = new List<GameObject>();
    int Vez;
    int Oportunidades;
    [Header("Monstruo1")]
    public GameObject Monstruo1;
    public Transform PosInicial;
    [Header("Monstruo2")]
    public GameObject Monstruo2;
    public Transform PosInicial2;
    [Header("Jugador")]
    public GameObject Transicion_Jugador;
    public float VelTransicion;
    [Header("sala1")]
    public GameObject CuartoBoss1;
    public GameObject Sala1Transicion;
    [Header("sala2")]
    public GameObject CuartoBoss2;
    public GameObject Sala2Transicion;
    private void Start()
    {
        Vez = Velas.Count;
    }
    
    public void PerderMonster1()
    {
        StartCoroutine(TransicionCuarto1());
    }
    public void PerderMonster2()
    {
        StartCoroutine(TransicionCuarto2());
    }
    void ApagarVela()
    {
        if(Oportunidades<Vez)
        {
            Velas[Oportunidades].SetActive(false);
            Oportunidades++;
        }
    }
    IEnumerator TransicionCuarto1()
    {
        Transicion_Jugador.SetActive(true);
        yield return new WaitForSeconds(1f);
        
        CuartoBoss1.SetActive(true);
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        yield return new WaitForSeconds(2.85f);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2.8f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4.5f;
        CuartoBoss1.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        ApagarVela();
        Transicion_Jugador.SetActive(false);
    }
    IEnumerator TransicionCuarto2()
    {
        Transicion_Jugador.SetActive(true);
        yield return new WaitForSeconds(1f);
        CuartoBoss2.SetActive(true);
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 7f;
        yield return new WaitForSeconds(2.85f);
        Transicion_Jugador.GetComponent<Animator>().SetTrigger("Apagar");
        Monstruo1.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2.8f;
        Monstruo2.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 4.5f;
        CuartoBoss2.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        ApagarVela();
        Transicion_Jugador.SetActive(false);
    }
}
