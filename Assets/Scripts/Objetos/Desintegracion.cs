using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desintegracion : MonoBehaviour
{
   // Material Colorrender;
    Animator Animacion;
    public bool Eliminar;
    public GameObject Padre;
    private void Start()
    {
        Animacion = this.GetComponent<Animator>();
           // Colorrender = this.GetComponent<MeshRenderer>().material;
            //Colorrender.SetFloat("_Weight", VerdeEsperanza);
       
    }
    public void Desintegrar(){
        this.GetComponent<Animator>().enabled = false;
    }
    void FixedUpdate(){
        if(Eliminar){
             Destroy(Padre);
        }
    }
}
