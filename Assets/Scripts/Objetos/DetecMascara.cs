using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetecMascara : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mascara")
        {
            //other.GetComponent<Rigidbody>().isKinematic=true;
            other.GetComponent<MascaraUse>().EnArea=true;
        }
    }
    private void OnTriggerExit(Collider otherexit)
    {
        if (otherexit.gameObject.tag == "Mascara")
        {
            otherexit.GetComponent<Rigidbody>().useGravity = true;
           // otherexit.GetComponent<Rigidbody>().isKinematic = false;
            otherexit.GetComponent<MascaraUse>().EnArea = false;
        }
    }
}
