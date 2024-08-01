using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desintegracion : MonoBehaviour
{
   // Material Colorrender;
    Animator Animacion;
    public bool Eliminar;
    public GameObject Padre;
    public SimbolMaster ObjParentFinal;
    public bool Primero=false;
    private void Start()
    {
        Animacion= GetComponent<Animator>();
    }
    public void Desintegrar(){
        Animacion.SetTrigger("Eliminar");
        StartCoroutine(EliminarObj());
    }
    IEnumerator EliminarObj()
    {

        yield return new WaitForSeconds(4);
        Padre.SetActive(false);
        ObjParentFinal.ActivarSiguienteSimbolo();
        if (Primero)
        {
            ObjParentFinal.IniciarJuego();
        }
        
    }
}
