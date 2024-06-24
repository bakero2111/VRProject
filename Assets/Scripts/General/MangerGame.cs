using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerGame : MonoBehaviour
{
    public GameObject Enemigo1;
    public GameObject Enemigo2;
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
        else if(!VelasHorario[VelasHorario.Count - 1].activeSelf)
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
        Enemigo1.GetComponent<DañoLuz>().IniciarDaño();
        StartCoroutine(Ganar());
    }
    IEnumerator Ganar()
    {

        yield return new WaitForSeconds(2);
        Enemigo1.SetActive(false);
        Enemigo2.SetActive(false);
    }
    
}
