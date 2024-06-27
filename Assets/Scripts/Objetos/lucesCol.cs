using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucesCol : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster1")
        {
            
            if(other.GetComponent<DañoLuz>().vida>=0)
            {
                if(!other.GetComponent<DañoLuz>().EnDanho){
            other.GetComponent<DañoLuz>().BajoLuz =true;
                }
            other.GetComponent<DañoLuz>().vida--;
            }
        }
    }
}
