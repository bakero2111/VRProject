using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarProta1 : MonoBehaviour
{
    public PerderCol Manager_MovJugador;
    public Mov_Monst_1 ObjPadreMovMnst;
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag=="Perder")
       {
          Manager_MovJugador.PerderMonster1();
       }
    }

}
