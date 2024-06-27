using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarProta1 : MonoBehaviour
{
    public PerderCol Manager_MovJugador;
    public Mov_Monst_1 ObjPadreMovMnst;
    public  bool Monster2;
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag=="Perder")
       {
         if(!Monster2){
          Manager_MovJugador.PerderMonster1();
         }
         else if(Monster2){
            Manager_MovJugador.PerderMonster2();
         }
       }
    }
}
