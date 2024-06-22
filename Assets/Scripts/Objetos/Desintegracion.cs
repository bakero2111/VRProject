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
        Animacion= GetComponent<Animator>();
           // Colorrender = this.GetComponent<MeshRenderer>().material;
            //Colorrender.SetFloat("_Weight", VerdeEsperanza);
       
    }
    public void Desintegrar(){
        Animacion.enabled = true;
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

        yield return new WaitForSeconds(1);
        Destroy(Padre);

        
    }
}
