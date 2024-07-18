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
           // Colorrender = this.GetComponent<MeshRenderer>().material;
            //Colorrender.SetFloat("_Weight", VerdeEsperanza);
       
    }
    public void Desintegrar(){
        //Animacion.enabled = true;
        Animacion.SetTrigger("Eliminar");
        StartCoroutine(EliminarObj());
    }
    /*
    void FixedUpdate(){
        if(Eliminar){
             Destroy(Padre);
        }
    }
    */
    IEnumerator EliminarObj()
    {

        yield return new WaitForSeconds(4);
        Destroy(Padre);
        ObjParentFinal.ActivarSiguienteSimbolo();
        if (Primero)
        {
            ObjParentFinal.IniciarJuego();
        }
        
    }
}
