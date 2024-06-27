using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegresarPos : MonoBehaviour
{
    public Vector3 Inicio;
    Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        Inicio = this.gameObject.transform.position;
        rbd= this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
     void OnCollisionEnter(Collision ColisionTel)
     {
        if(ColisionTel.gameObject.tag=="Piso"){
            Debug.Log("asda");
            rbd.Sleep();
            
            this.transform.position = Inicio;
            rbd.WakeUp();
        }
    }
}
