using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lucesCol : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Monster1")
        {
            if(other.GetComponent<Da�oLuz>().vida>=0)
            other.GetComponent<Da�oLuz>().vida--;
        }
    }
}
